using System;

namespace lab_work_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int MAXN = 5;
            const int MAXQ = 5;
            Random rand = new Random();

            Fraction[] test = new Fraction[MAXN];

            for (int i = 0; i < MAXN; ++i)
            {
                test[i] = new Fraction(rand.Next(-20, 100), rand.Next(1, 100));
            }

            Console.WriteLine("Current array: ");

            Console.WriteLine("Simple representation: ");
            for (int i = 0; i < MAXN; ++i)
            {
                Console.Write(test[i].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Int: ");
            for (int i = 0; i < MAXN; ++i)
            {
                Console.Write(test[i].ToString("XX") + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Double: ");
            for (int i = 0; i < MAXN; ++i)
            {
                Console.Write(test[i].ToString("XX.YY") + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            /* sorting */
            Array.Sort(test);
            Console.WriteLine("Sorted array: ");
            Console.WriteLine("Simple representation: ");
            for (int i = 0; i < MAXN; ++i)
            {
                Console.Write(test[i].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Int: ");
            for (int i = 0; i < MAXN; ++i)
            {
                Console.Write(test[i].ToString("XX") + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Double: ");
            for (int i = 0; i < MAXN; ++i)
            {
                Console.Write(test[i].ToString("XX.YY") + " ");
            }
            Console.WriteLine();

            /* random fractions compare */

            for (int i = 0; i < MAXQ; ++i)
            {
                Fraction a = new Fraction(rand.Next(-20, 100), rand.Next(1, 100));
                Fraction b = new Fraction(rand.Next(-20, 100), rand.Next(1, 100));

                Console.WriteLine(a.ToString("XX.YY") + " and " + b.ToString("XX.YY"));
                Console.WriteLine(">= result is " + (a >= b).ToString());
                Console.WriteLine("<= result is " + (a <= b).ToString());
                Console.WriteLine("> result is " + (a > b).ToString());
                Console.WriteLine("< result is " + (a < b).ToString());
                Console.WriteLine("== result is " + (a == b).ToString());
                Console.WriteLine("!= result is " + (a != b).ToString());
            }
            Console.WriteLine();

            /* random fractions operations */

            for (int i = 0; i < MAXQ; ++i)
            {
                Fraction a = new Fraction(rand.Next(-20, 100), rand.Next(1, 100));
                Fraction b = new Fraction(rand.Next(-20, 100), rand.Next(1, 100));
                Console.WriteLine(a.ToString("XX.YY") + " and " + b.ToString("XX.YY"));
                Console.WriteLine("a + b result is " + (a + b).ToString("XX.YY"));
                Console.WriteLine("a * b result is " + (a * b).ToString("XX.YY"));
                Console.WriteLine("a / b result is " + (a / b).ToString("XX.YY"));
                Console.WriteLine("a - b result is " + (a - b).ToString("XX.YY"));
                a++;
                Console.WriteLine("a++ result is " + a.ToString("XX.YY"));
                a--;
                Console.WriteLine("a-- result is " + a.ToString("XX.YY"));
                Console.WriteLine("(int)a result is " + ((int)a).ToString());
                Console.WriteLine("(double)a result is " + ((double)a).ToString());
            }

            /* test regular expressions */

            string[] randStrings = new string[] { "hi", "     0.22", "1.22     ", "  +555", "       -555+5123", "     -22/44", "   -12312/22" };

            foreach (string item in randStrings)
            {
                Fraction fraction;
                Console.WriteLine("string is `" + item + "`");
                try
                {
                    fraction = Fraction.Parse(item);
                    Console.WriteLine(fraction.ToString());
                    Console.WriteLine(fraction.ToString("XX.YY"));
                    Console.WriteLine(fraction.ToString("XX"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {

            }
        }
    }
}
