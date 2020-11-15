using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_work_task_2
{
    public class NextSymSolution
    {
        private List<char> line;
        private string letters;
        public NextSymSolution(string input)
        {
            line = new List<char>();

            for (int i = 0; i < input.Length; ++i) line.Add(input[i]);
      
            for (char i = 'a'; i <= 'z'; ++i) letters += i.ToString();
            letters += 'a'.ToString();
        }

        public void Calc()
        {
            for (int i = 0; i < line.Count; i++)
            {
                string sym = line[i].ToString();
                line[i] = letters[letters.IndexOf(sym) + 1];
            }

            for (int i = 0; i < line.Count; ++i)
            {
                Console.Write(line[i] + (i == line.Count - 1 ? "\n" : ""));
            }
        }

    }
}
