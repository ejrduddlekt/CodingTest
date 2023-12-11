using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class Level2_프로세스
{
    public int solution(int[] priorities, int location)
    {
        int answer = 0;

        List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
        
        for(int i = 0; i < priorities.Length; i++)
        {
            list.Add(new KeyValuePair<int, int>(i, priorities[i]));
        }

        int process = -1;

        while(true)
        {
            if (process == location)
                break;

            int maxValue = list.Max(x => x.Value);
            int maxKey = -1;
            
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].Value == maxValue)
                {
                    maxKey = list[i].Key;
                    break;
                }
            }

            if (list[0].Key == maxKey)
            {
                process = list[0].Key;
                list.RemoveAt(0);
                answer += 1;
                continue;
            }
            else
            {
                list.Add(list[0]);
                list.RemoveAt(0);
            }
        } 

        Console.WriteLine(answer);
        return answer;
    }
}

//class Program
//{
//    static void Main()
//    {
//        Level2_프로세스 solution = new Level2_프로세스();

//        int[] participant = new int[] { 1, 1, 9, 1, 1, 1};

//        int result = solution.solution(participant, 5);

//        Console.WriteLine($"Result: {result}");
//    }
//}