using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 프로그래머스.알고리즘.스택_큐;

namespace 프로그래머스.알고리즘.스택_큐
{
    public class Level2_다리를_지나는_트럭
    {
        public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            int answer = 0;

            int bridge_Weight = 0;
            int truck_weights_index = 0;
            List<int[]> list = new List<int[]>();

            while (true)
            {
                if (truck_weights_index == truck_weights.Length && list.Count == 0 && answer != 0)
                    break;

                answer++;

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    list[i][1]++;
                    if (list[i][1] == bridge_length)
                    {
                        bridge_Weight -= list[i][0];
                        list.RemoveAt(i);
                    }
                }

                if (truck_weights_index < truck_weights.Length || truck_weights_index == 0)
                {
                    if (truck_weights[truck_weights_index] + bridge_Weight <= weight)
                    {
                        list.Add(new int[] { truck_weights[truck_weights_index], 0 });
                        bridge_Weight += truck_weights[truck_weights_index];
                        truck_weights_index++;
                    }
                }
            }

            Console.WriteLine(answer);
            return answer;
        }
    }
}


//class Program
//{
//    static void Main()
//    {
//        Level2_다리를_지나는_트럭 solution = new Level2_다리를_지나는_트럭();

//        int[] participant = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

//        int result = solution.solution(100, 100, participant);

//        Console.WriteLine($"Result: {result}");
//    }
//}