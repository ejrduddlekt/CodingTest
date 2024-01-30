using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 프로그래머스.알고리즘.탐욕법_Gready_
{
    internal class Lv1_체육복
    {
        public int solution(int n, int[] lost, int[] reserve)
        {
            int answer = 0;
            int[] studentCloths = new int[n];

            foreach (int student in lost)
            {
                studentCloths[student - 1]--;
            }

            foreach (int student in reserve)
            {
                studentCloths[student - 1]++;
            }

            for (int i = 0; i < studentCloths.Length; i++)
            {
                if (studentCloths[i] == -1)
                {
                    if (i > 0)
                    {
                        if (studentCloths[i - 1] > 0)
                        {
                            studentCloths[i]++;
                            studentCloths[i - 1]--;
                            continue;
                        }
                    }

                    if (i < studentCloths.Length - 1)
                    {
                        if (studentCloths[i + 1] > 0)
                        {
                            studentCloths[i]++;
                            studentCloths[i + 1]--;
                        }
                    }
                }
            }


            for (int i = 0; i < studentCloths.Length; i++)
            {
                if (studentCloths[i] != -1)
                    answer++;
            }

            return answer;
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        Lv1_체육복 solution = new Lv1_체육복();

    //        int[] lost = new int[] { 2, 4 };
    //        int[] reserve = new int[] { 1, 3, 5 };

    //        int result = solution.solution(5, lost, reserve);

    //        Console.WriteLine($"Result: {result}");
    //    }
    //}
}
