using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_work_task_2
{
    public class FindNumbersSolution
    {
        private string[] numbers;

        private readonly char[] is_16 =
            {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        public FindNumbersSolution(string input)
        {
            numbers = input.Split(' ');
        }

        public void Calc()
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                int correct = 1;
                int power = 1;
                int ans = 0;
                for (int j = numbers[i].Length - 1; j >= 0; --j)
                {
                    int pos = Array.IndexOf(is_16, numbers[i][j]);

                    if (pos == -1)
                    {
                        correct = 0;
                        break;
                    }

                    ans += power * pos;
                    power *= 16;
                }

                if (correct != 0)
                {
                    Console.WriteLine(numbers[i] + " => " + ans);
                }
            }
        }
    }
}
