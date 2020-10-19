using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_work_task_2
{
    public class RandomStringGenerator
    {

        private string letters;
        private int len;
        private Random rnd;

        public RandomStringGenerator(string input)
        {
            rnd = new Random();
            
            while (true)
            {
                try
                {
                    len = int.Parse(input);
                    break;
                } 
                catch (Exception)
                {
                    Console.WriteLine("Please insert your number correctly: ");
                    input = Console.ReadLine();
                    continue;
                }
            }
            
            for (char i = 'a'; i <= 'z'; ++i) letters += i.ToString();

        }

        public void Generate()
        {
            string ans = "";
            for (int i = 0; i < len; ++i) ans += (letters[rnd.Next(letters.Length)]).ToString();

            Console.WriteLine("random line is: " + ans);
        }
    }
}
