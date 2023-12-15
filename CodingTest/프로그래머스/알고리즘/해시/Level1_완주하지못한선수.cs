using System;
using System.Collections.Generic;
using System.Linq;

public class Hash_1
{
    public string solution(string[] participant, string[] completion)
    {
        string answer = "";
        List<string> strings = participant.ToList();

        foreach (var item in completion)
        {
            strings.Remove(item);
        }
        answer = strings[0];

        return answer;
    }
}

//class Program
//{
//    static void Main()
//    {
//        Hash_1 solution = new Hash_1();

//        string[] participant = new string[] { "mislav", "stanko", "mislav", "ana" };
//        string[] completion = new string[] { "stanko", "ana", "mislav" };

//        string result = solution.solution(participant, completion);

//        Console.WriteLine($"Result: {result}");
//    }
//}
//