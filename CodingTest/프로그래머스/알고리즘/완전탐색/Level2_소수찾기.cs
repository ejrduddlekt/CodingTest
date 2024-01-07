using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Level2_소수찾기
{
    public int solution(string numbers)
    {
        int answer = 0;
        int[] nums = numbers.Select(n => (int)Char.GetNumericValue(n)).ToArray();
        int maxDigits = numbers.Length;
        var combinations = new HashSet<string>(); // HashSet을 사용하여 중복 제거


        for (int digits = 1; digits <= maxDigits; digits++)
        {
            GenerateCombinations(nums, "", digits, combinations);
        }

        List<int> ints = new List<int>();

        foreach (var num in combinations)
        {
            if (소수찾기(int.Parse(num))) { ints.Add(int.Parse(num)); }
        }
        answer = ints.Count;

        return answer;
    }

    void GenerateCombinations(int[] numbers, string current, int digitsLeft, HashSet<string> combinations)
    {
        if (digitsLeft == 0)
        {
            if (!string.IsNullOrEmpty(current))
            {
                string normalizedCombo = int.Parse(current).ToString();
                combinations.Add(normalizedCombo);
            }
            return;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            var newNumbers = numbers.ToList();
            newNumbers.RemoveAt(i); // 인덱스를 사용하여 요소 제거
            string st = current + numbers[i];

            GenerateCombinations(newNumbers.ToArray(), st, digitsLeft - 1, combinations);
        }
    }

    public bool 소수찾기(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

class Program
{
    static void Main()
    {
        Level2_소수찾기 solution = new Level2_소수찾기();

        string participant = "111";

        int result = solution.solution(participant);

        Console.WriteLine($"Result: {result}");
    }
}
