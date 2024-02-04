using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 프로그래머스.코딩인터뷰_완전분석._1_배열과문자열;

/*
 Q - 문자열 2개가 주어졌을 때 이 둘이 서로 순열 관계에 있는지 확인하는 메서드를 작성하라. 
 */
namespace 프로그래머스.코딩인터뷰_완전분석._1_배열과문자열
{
    internal class _2_순열확인
    {
// 방법1 ----- 정렬 후 값이 같은지 확인
        public bool solution_1(string stringA, string stringB)
        {
            if (stringA.Length != stringB.Length)
                return false;

            char[] A = stringA.ToCharArray();
            char[] B = stringB.ToCharArray();

            //Array.Sort(stringA.ToCharArray());
            //Array.Sort(stringB.ToCharArray()); 값의 복사가 일어나므로 다음 구문은 적용되지 않는다.
            Array.Sort(A);
            Array.Sort(B);

            return A.SequenceEqual(B); //SequenceEqual은 두 배열이 동일한 순서과 동일한 값인지 확인하는 메서드이다.
        }

// 방법2 ----- Hash 및 Dictionary를 통한 방법
        public bool solution_2(string stringA, string stringB)
        {
            if (stringA.Length != stringB.Length)
                return false;

            Dictionary<char, int> charMapA = new Dictionary<char, int>();
            Dictionary<char, int> charMapB = new Dictionary<char, int>();

            // stringA의 각 문자에 대해 카운트를 증가
            foreach (char c in stringA)
            {
                if (charMapA.ContainsKey(c))
                    charMapA[c]++;
                else
                    charMapA[c] = 1;
            }

            // stringB의 각 문자에 대해 카운트를 증가
            foreach (char c in stringB)
            {
                if (charMapB.ContainsKey(c))
                    charMapB[c]++;
                else
                    charMapB[c] = 1;
            }

            foreach (var pair in charMapA)
            {
                //B에 동일한 키가 없거나, value값이 다를 때는 false를 반환
                if (!charMapB.ContainsKey(pair.Key) || charMapB[pair.Key] != pair.Value)
                    return false;
            }

            return true;
        }

        // 방법3 ----- Hash 및 Dictionary를 통한 방법
        public bool solution_3(string stringA, string stringB)
        {
            if (stringA.Length != stringB.Length)
                return false;

            Dictionary<char, int> charMap = new Dictionary<char, int>();

            // stringA의 각 문자에 대해 카운트를 증가
            foreach (char c in stringA)
            {
                if (charMap.ContainsKey(c))
                    charMap[c]++;
                else
                    charMap[c] = 1;
            }

            // stringB의 각 문자에 대해 카운트를 증가
            foreach (char c in stringB)
            {
                if (charMap.ContainsKey(c) && charMap[c] != 0)
                    charMap[c]--;
                else
                    return false;
            }

            return true;
        }
    }

    //public delegate bool CustomDelegate(string a, string b);
    //class Program
    //{
    //    static void Main()
    //    {
    //        _2_순열확인 solution = new _2_순열확인();

    //        CustomDelegate customDelegate = solution.solution_3;


    //        Console.WriteLine($"Result: {customDelegate("a","aab")}");
    //        Console.WriteLine($"Result: {customDelegate("aba","abb")}");
    //        Console.WriteLine($"Result: {customDelegate("hooh","oohh")}");
    //        Console.WriteLine($"Result: {customDelegate("aaabbbccc","abcabcabc")}");
    //        Console.WriteLine($"Result: {customDelegate("abaa","abba")}");
    //    }
    //}
}
