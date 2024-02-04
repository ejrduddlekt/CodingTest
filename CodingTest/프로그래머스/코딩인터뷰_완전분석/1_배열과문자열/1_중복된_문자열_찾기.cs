using System;
using System.Collections.Generic;

namespace 프로그래머스.코딩인터뷰_완전분석._1_배열과문자열
{
    internal class _1_중복된_문자열_찾기
    {
        public bool solution_1(string testCase)
        {
            for (int i = 0; i < testCase.Length - 1; i++)
                for (int j = i + 1; j < testCase.Length; j++)
                    if (testCase[i] == testCase[j])
                        return false;
            return true;
        }

        public bool solution_2(string testCase)
        {
            Dictionary<int, bool> dicString = new Dictionary<int, bool>();

            for (int i = 0; i < testCase.Length; i++)
            {
                if (dicString.ContainsKey(testCase[i]))
                {
                    return false;
                }
                dicString.Add(testCase[i], true);
            }
            return true;
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        _1_중복된_문자열_찾기 solution = new _1_중복된_문자열_찾기();

    //        Console.WriteLine($"Result: {solution.solution_2("")}");
    //        Console.WriteLine($"Result: {solution.solution_2("abcd")}");
    //        Console.WriteLine($"Result: {solution.solution_2("abccd")}");
    //        Console.WriteLine($"Result: {solution.solution_2("bhjjb")}");
    //        Console.WriteLine($"Result: {solution.solution_2("mdjq")}");
    //        Console.WriteLine($"Result: {solution.solution_2("geez")}");
    //    }
    //}
}
