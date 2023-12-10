using System;
using System.Collections.Generic;


public class Level2_의상
{
    public int solution(string[,] clothes)
    {
        int answer = 0;

        Dictionary<string, List<string>> datas = new Dictionary<string, List<string>>();


        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            string key = clothes[i, 1];

            if (datas.ContainsKey(key))
            {
                datas[key].Add(clothes[i, 0]);
            }
            else
            {
                datas.Add(clothes[i, 1], new List<string> { clothes[i, 0] });
            }
        }

        foreach (string key in datas.Keys)
        {
            if (answer == 0)
            {
                answer = 1;
                answer *= datas[key].Count + 1;
            }
            else
            {
                answer *= datas[key].Count + 1;
            }
        }


        return answer - 1;
    }
}


//class Program
//{
//    static void Main()
//    {
//        Level2_의상 solution = new Level2_의상();

//        string[,] participant = new string[,] { { "yellow_hat", "headgear" }, { "blue_sunglasses", "eyewear" }, { "green_turban", "headgear" } };

//        int result = solution.solution(participant);

//        Console.WriteLine($"Result: {result}");
//    }
//}