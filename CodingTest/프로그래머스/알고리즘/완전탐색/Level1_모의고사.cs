using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Level1_모의고사
{
    public int[] solution(int[] answers)
    {
        int[] answer = new int[] { };

        int[] correctPoint = new int[3];

        int[] people_1 = new int[] { 1, 2, 3, 4, 5 };
        int[] people_2 = new int[] { 2, 1, 2, 3, 2, 4, 2, 5 };
        int[] people_3 = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

        for(int i = 0; i < answers.Length; i++)
        {
            int correct = answers[i];

            if(people_1[i % people_1.Length] == correct)
                correctPoint[0]++;

            if (people_2[i % people_2.Length] == correct)
                correctPoint[1]++;

            if (people_3[i % people_3.Length] == correct)
                correctPoint[2]++;
        }

        int maxPoint = correctPoint.Max();
        List<int> maxPointPeople = new List<int>();

        for(int i = 0; i < 3; i++)
        {
            if(maxPoint == correctPoint[i])
                maxPointPeople.Add(i+1);
        }

        answer = maxPointPeople.ToArray();
        return answer;
    }
}

//class Program
//{
//    static void Main()
//    {
//        Level1_모의고사 solution = new Level1_모의고사();

//        int[] participant = new int[] { 1, 2, 3, 4, 5 };

//        int[] result = solution.solution(participant);

//        Console.WriteLine($"Result: {result}");
//    }
//}

