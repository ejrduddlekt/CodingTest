using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY)
    {
        int answer = 0;

        int[,] road = new int[200, 200];


        List<int[]> checkPointRepository = new List<int[]>();
        List<int> finishData = new List<int>();

        checkPointRepository.Add(new int[] { characterX * 2, characterY * 2, 0, -1 });


        //도형 그리기
        for (int i = 0; i < rectangle.GetLength(0); i++)
        {
            int xMin = rectangle[i, 0] * 2;
            int xMax = rectangle[i, 2] * 2;
            int yMin = rectangle[i, 1] * 2;
            int yMax = rectangle[i, 3] * 2;


            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    if (x != xMin && x != xMax && y != yMin && y != yMax)
                    {
                        road[x, y] = 1;
                    }
                    else if ((x == xMin || x == xMax || y == yMin || y == yMax) && road[x, y] == 0)
                    {
                        road[x, y] = 2;
                    }
                }
            }
        }

        road[characterX * 2, characterY * 2] = 7;
        road[itemX * 2, itemY * 2] = 9;


        //좌표 출력
        for (int i = road.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < road.GetLength(1); j++)
            {
                if (j == 0)
                {
                    Console.Write(i + "\t");
                }
                Console.Write(road[j, i] + "  ");
            }
            Console.Write("\n");
        }
        Console.Write("\n");
        Console.Write("\t");
        for (int i = 0; i < 25; i++)
        {
            if (i < 10)
                Console.Write(i + "  ");
            else
                Console.Write(i + " ");
        }
        Console.Write("\n");


        while (checkPointRepository.Count != 0)
        {
            int[] characterPoint = checkPointRepository[0];
            checkPointRepository.Remove(characterPoint);

            //아랫길 탐색 
            if (road[characterPoint[0], characterPoint[1] - 1] == 2 && characterPoint[3] != 1)
            {
                int pointX = characterPoint[0];
                int pointY = characterPoint[1] - 1;
                int moveStack = characterPoint[2];

                int roadValue = road[pointX, pointY];

                for (int y = pointY; road[pointX, y] == 2; y--)
                {
                    pointY = y;
                    moveStack++;
                }

                if (road[pointX, pointY - 1] == 9)
                {
                    moveStack++;
                    finishData.Add(moveStack);
                    continue;
                }

                checkPointRepository.Add(new int[] { pointX, pointY, moveStack, 1 });
            }

            //윗길 탐색
            if (road[characterPoint[0], characterPoint[1] + 1] == 2 && characterPoint[3] != 1)
            {
                int pointX = characterPoint[0];
                int pointY = characterPoint[1] + 1;
                int moveStack = characterPoint[2];

                int roadValue = road[pointX, pointY];

                for (int y = pointY; road[pointX, y] == 2; y++)
                {
                    pointY = y;
                    moveStack++;
                }

                if (road[pointX, pointY + 1] == 9)
                {
                    moveStack++;
                    finishData.Add(moveStack);
                    continue;
                }

                checkPointRepository.Add(new int[] { pointX, pointY, moveStack, 1 });
            }

            //좌측 탐색
            if (road[characterPoint[0] - 1, characterPoint[1]] == 2 && characterPoint[3] != 0)
            {
                int pointX = characterPoint[0] - 1;
                int pointY = characterPoint[1];
                int moveStack = characterPoint[2];

                int roadValue = road[pointX, pointY];

                for (int x = pointX; road[x, pointY] == 2; x--)
                {
                    pointX = x;
                    moveStack++;
                }

                if (road[pointX - 1, pointY] == 9)
                {
                    moveStack++;
                    finishData.Add(moveStack);
                    continue;
                }

                checkPointRepository.Add(new int[] { pointX, pointY, moveStack, 0 });
            }

            //우측 탐색
            if (road[characterPoint[0] + 1, characterPoint[1]] == 2 && characterPoint[3] != 0)
            {
                int pointX = characterPoint[0] + 1;
                int pointY = characterPoint[1];
                int moveStack = characterPoint[2];

                int roadValue = road[pointX, pointY];

                for (int x = pointX; road[x, pointY] == 2; x++)
                {
                    int roadValue2 = road[x, pointY];
                    pointX = x;
                    moveStack++;
                }

                if (road[pointX + 1, pointY] == 9)
                {
                    moveStack++;
                    finishData.Add(moveStack);
                    continue;
                }

                checkPointRepository.Add(new int[] { pointX, pointY, moveStack, 0 });
            }
        }

        answer = finishData.Min()/2;

        
        return answer;
    }


    //class Program
    //{
    //    static void Main()
    //    {
    //        Solution solution = new Solution();

    //        int[,] rectangle = new int[,]
    //        {
    //        {1, 1, 7, 4},
    //        {3, 2, 5, 5},
    //        {4, 3, 6, 9},
    //        {2, 6, 8, 8}
    //        };

    //        int characterX = 1;
    //        int characterY = 3;
    //        int itemX = 5;
    //        int itemY = 9;

    //        int result = solution.solution(rectangle, characterX, characterY, itemX, itemY);

    //        Console.WriteLine($"Result: {result}");
    //    }
    //}
}