using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Level3_베스트앨범
{
    public int[] solution(string[] genres, int[] plays)
    {
        int[] answer = new int[] { };
        List<int> answerList = new List<int>();
        Dictionary<string, int> datas = new Dictionary<string, int>();

        for (int i = 0; i < genres.Length; i++)
        {
            if (datas.ContainsKey(genres[i]))
            {
                datas[genres[i]] += plays[i];
            }
            else
            {
                datas.Add(genres[i], plays[i]);
            }
        }

        List<KeyValuePair<string, int>> sortedList = datas.ToList();
        sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));

        foreach (KeyValuePair<string, int> data in sortedList)
        {
            List<KeyValuePair<int, int>> songList = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < genres.Length; i++)
            {
                if (data.Key == genres[i])
                {
                    songList.Add(new KeyValuePair<int, int>(i, plays[i]));
                }
            }

            songList.Sort((x, y) => y.Value.CompareTo(x.Value));

            for (int i = 0; i < songList.Count; i++)
            {
                if (i < 2)
                    answerList.Add(songList[i].Key);
            }
        }

        answer = answerList.ToArray();
        return answer;
    }
}

//class Program
//{
//    static void Main()
//    {
//        Level3_베스트앨범 solution = new Level3_베스트앨범();

//        string[] participant = new string[] { "classic", "pop", "classic", "classic", "pop" };
//        int[] participant2 = new int[] { 500, 600, 150, 800, 2500 };

//        int[] result = solution.solution(participant, participant2);

//        Console.WriteLine($"Result: {result}");
//    }
//}