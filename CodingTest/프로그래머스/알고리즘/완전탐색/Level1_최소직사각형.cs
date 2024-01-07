using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Level1_최소직사각형
{
    public int solution(int[,] sizes)
    {
        int answer = 0;

        int[] horizontal = new int[sizes.GetLength(0)];
        int[] vertical = new int[sizes.GetLength(0)];


        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            int[] tempArray = { sizes[i, 0], sizes[i, 1] };
            Array.Sort(tempArray);
            horizontal[i] = tempArray[0];
            vertical[i] = tempArray[1];

            /* 비교연산 방법 3가지
                3항연산:
                    int biggerNum = sizes[i, 0] < sizes[i, 1] ? sizes[i, 1] : sizes[i, 0];

                linq방법: 
                    int biggerNum = new int[] { sizes[i, 0], sizes[i, 1] }.Max();

                sort방법(sort는 2차원 배열에선 사용이 불가능하다.): 
                    int[] tempArray = { sizes[i, 0], sizes[i, 1] };
                    Array.Sort(tempArray);
                    sizes[i, 0] = tempArray[0];
                    sizes[i, 1] = tempArray[1];
            */
        }

        answer = horizontal.Max() * vertical.Max();
        return answer;
    }
}


//class Program
//{
//    static void Main()
//    {
//        Level1_최소직사각형 solution = new Level1_최소직사각형();

//        int[,] participant = new int[,] { { 60, 50 }, { 30, 70 }, { 60, 30 }, { 80, 40 } };

//        int result = solution.solution(participant);

//        Console.WriteLine($"Result: {result}");
//    }
//}