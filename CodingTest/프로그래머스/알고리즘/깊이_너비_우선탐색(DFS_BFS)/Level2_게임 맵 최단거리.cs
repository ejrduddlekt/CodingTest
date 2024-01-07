using System;
using System.Collections.Generic;

namespace 프로그래머스.알고리즘.깊이_너비_우선탐색_DFS_BFS_
{
    class Solution
    {
        public int solution(int[,] maps)
        {
            int answer = 0;
            int[,] load = new int[maps.GetLength(0), maps.GetLength(1)];

            List<int[]> paths = new List<int[]>();

            while (true)
            {
                if (paths.Count == 0)
                {
                    if (answer == 0)
                    {
                        int[] curCharacter = new int[] { 0, 0 };
                        bool checkLoad = false;

                        if(maps.GetLength(0) > 1)
                        {
                            if (maps[1, 0] == 1)
                            {
                                paths.Add(new int[] { 1, 0 });
                                checkLoad = true;
                            }
                        }


                        if (maps.GetLength(1) > 1)
                        {
                            if (maps[0, 1] == 1)
                            {
                                paths.Add(new int[] { 0, 1 });
                                checkLoad = true;
                            }
                        }

                        if (checkLoad == false && maps.GetLength(1) != 1 && maps.GetLength(0) != 1)
                            return -1;
                        else if (checkLoad == false && maps.GetLength(1) == 1 && maps.GetLength(0) == 1)
                            return 0;
                    }

                    else
                    {
                        if (load[maps.GetLength(0) - 1, maps.GetLength(1) - 1] == 0)
                            return -1;
                        else
                            return load[maps.GetLength(0) - 1, maps.GetLength(1) - 1] + 1;
                    }
                }
                else
                {
                    List<int[]> nextPaths = new List<int[]>();

                    foreach (var path in paths)
                    {
                        load[path[0], path[1]] = answer;
                        nextPaths.AddRange(Finder(maps, load, path));
                    }
                    paths.Clear();
                    paths = nextPaths;
                }

                answer++;
            }
        }

        public List<int[]> Finder(int[,] maps, int[,] load, int[] path)
        {
            List<int[]> nextPaths = new List<int[]>();
            int nextPoint;

            //윗길
            nextPoint = path[1] - 1;

            if (nextPoint >= 0)
            {
                if (maps[path[0], nextPoint] == 1 && (path[0] + path[1] - 1 != 0))
                {
                    if (load[path[0], nextPoint] == 0)
                        nextPaths.Add(new int[] { path[0], nextPoint });
                }
            }


            //아랫길
            nextPoint = path[1] + 1;

            if (nextPoint < maps.GetLength(1))
            {
                if (maps[path[0], nextPoint] == 1)
                {
                    if (load[path[0], nextPoint] == 0)
                        nextPaths.Add(new int[] { path[0], nextPoint });
                }
            }


            //좌
            nextPoint = path[0] - 1;

            if (nextPoint >= 0)
            {
                if (maps[nextPoint, path[1]] == 1 && (path[0] + path[1] - 1 != 0))
                {
                    if (load[nextPoint, path[1]] == 0)
                        nextPaths.Add(new int[] { nextPoint, path[1] });
                }
            }


            //우
            nextPoint = path[0] + 1;

            if (nextPoint < maps.GetLength(0))
            {
                if (maps[nextPoint, path[1]] == 1)
                {
                    if (load[nextPoint, path[1]] == 0)
                        nextPaths.Add(new int[] { nextPoint, path[1] });
                }
            }
            return nextPaths;
        }
    }

    //class program
    //{
    //    static void main()
    //    {
    //        solution solution = new solution();

    //        int[,] rectangle = new int[,]
    //        {
    //        {1},
    //        };

    //        int result = solution.solution(rectangle);

    //        console.writeline($"result: {result}");
    //    }
    //}
}
