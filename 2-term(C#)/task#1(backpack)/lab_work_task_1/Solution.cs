using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_work_task_1
{
    class Solution
    {

        private int numberThings, maxWeight;
        private int[] weight;
        private int[] price;
        public Solution()
        {

            Console.WriteLine("Enter number of thigs: ");

            this.numberThings = getOneNumber();


            this.weight = new int[numberThings];
            this.price = new int[numberThings];

            Console.WriteLine("Enter max weight: ");


            this.maxWeight = getOneNumber();


            Console.WriteLine("Things(weight, price): ");
            for (int i = 0; i < numberThings; ++i)
            {
                List <int> input = getTwoNumbers();
                weight[i] = input[0];
                price[i] = input[1];
            }
        }

        public void Calc()
        {
            int[] dp = new int[maxWeight + 1];

            dp[0] = 0;

            int mx = 0;

            for (int i = 0; i < numberThings; ++i)
            {
                for (int j = maxWeight; j >= weight[i]; j--)
                {

                    if (j - weight[i] >= 0)
                    {
                        dp[j] = Math.Max(dp[j - weight[i]] + price[i], dp[j]);
                    }
                }
            }

            for (int j = 0; j <= maxWeight; ++j) mx = Math.Max(dp[j], mx);

            Console.WriteLine("We can to wrap up thing on " + mx.ToString());
        }

        private int getOneNumber()
        {
            while (true)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine().Trim());
                    if (number < 0) throw new Exception();
                    return number;
                }
                catch (Exception)
                {
                    Console.WriteLine("Your number incorrect, try again");
                }
            }
        }

        private List <int> getTwoNumbers()
        {
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Trim().Split(' ');
                    List<int> arr = new List<int>();
                    
                    for (int i = 0; i < input.Length; ++i) if (input[i].Length != 0) arr.Add(int.Parse(input[i]));
                    
                    if (arr.Count != 2 || arr[0] < 0 || arr[1] < 0) throw new Exception();
                    return arr;
                }
                catch (Exception)
                {
                    Console.WriteLine("Your numbers is incorrect, try again");
                }
            }
        }
    }
}
