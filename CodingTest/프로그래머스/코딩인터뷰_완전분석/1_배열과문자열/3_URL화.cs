using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Q - 주어진 문자열 내의 모든 공백을 '%20'으로 바꾸는 메서드를 작성하라. 문자열 끝에 필요한 문자들을
    더할 수 있는 충분한 공간이 있다고 가정하라.

input: "Mr John Smith   ", 13
output: "Mr%20John%20Smith"
 */

namespace 프로그래머스.코딩인터뷰_완전분석._1_배열과문자열
{
    internal class _3_URL화
    {
        public string solution_1(string s, int n)
        {
            s = s.Trim(); //Trim : 문자열 앞 뒤 공백을 제거
            string modifiedString = s.Replace(" ", "%20");

            return modifiedString;
        }

        //c# 라이브러리의 함수를 사용하지 않을 때
        /*
        1. 문자열의 실제 길이 n
        2. 문자열 내부의 공백 갯수 = s.length - n

        1. 문자열 앞에 있는 공백의 갯수
        2. 문자열 뒤에있는 공백의 갯수

        !!! Logic
        1. 문자열 앞공백 처리
        2. 문자열 내부의 공백의 갯수
        3. 문자열 뒷 공백 처리
         */
        public string solution_2(string s, int n)
        {
            int stringLenth = s.Length;
            int frontEmpty = 0;
            int backEmpty = 0;

            string output = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    frontEmpty++;
                }
                else
                    break;
            }

            //s.Remove(0, frontEmpty - 1);
            //s.Remove(n, backEmpty - 1);

            backEmpty = stringLenth - frontEmpty - n;
            for (int i = frontEmpty; i < s.Length - backEmpty; i++)
            {
                if (s[i] == ' ')
                    output += "%20";
                else
                    output += s[i];
            }

            return output;
        }
    }

    public delegate string CustomDelegate(string a, int b);
    class Program
    {
        static void Main()
        {
            _3_URL화 solution = new _3_URL화();

            CustomDelegate customDelegate = solution.solution_2;


            Console.WriteLine($"Result: {customDelegate("Mr John Smith   ", 13)}");
            Console.WriteLine($"Result: {customDelegate("  Mr John Smith   ", 13)}");
            Console.WriteLine($"Result: {customDelegate("  Coding Moon  ", 11)}");
        }
    }
}
