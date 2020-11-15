using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace lab_work_task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            //1 task solution
            Console.Write("Insert your line, which contains 16-ric system elements: ");
            string input = Console.ReadLine();
            FindNumbersSolution sol = new FindNumbersSolution(input);
            sol.Calc();
            
            //2 task solution
            Console.Write("Insert size of line which you need to generate: ");
            input = Console.ReadLine();
            RandomStringGenerator solRnd = new RandomStringGenerator(input);
            solRnd.Generate();
            
            //3 task solution
            Console.Write("Insert your line to calculate: ");
            input = Console.ReadLine();
            NextSymSolution solCalc = new NextSymSolution(input);
            solCalc.Calc();
        }
    }
}