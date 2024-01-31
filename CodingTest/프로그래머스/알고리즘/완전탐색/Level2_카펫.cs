using System;

namespace 프로그래머스.알고리즘.완전탐색
{
    internal class Level2_카펫
    {
        public int[] solution(int brown, int yellow)
        {
            int[] answer = new int[] { };

            int addValue = brown + yellow;
            int sqrtValue = (int)Math.Sqrt(addValue);

            for (int i = 2; i <= sqrtValue; i++)
            {
                if ((addValue % i) == 0)
                {
                    int horizontal = i - 2;
                    int vertical = (addValue / i) - 2;

                    if(horizontal * vertical == yellow)
                    {
                        answer = horizontal > vertical ? new int[] { i, addValue / i } : new int[] { addValue / i, i };
                        break;
                    }
                }
            }

            return answer;
        }
    }
}
