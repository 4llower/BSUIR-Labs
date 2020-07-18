using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitTree
{
    class Program
    {
        [DllImport("ImplicitTreeDllCode.dll")]
        public static extern void insert(int value);

        [DllImport("ImplicitTreeDllCode.dll")]
        public static extern void erase(int value);

        [DllImport("ImplicitTreeDllCode.dll")]
        public static extern int getAmountBetween(int left, int right);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add a new element\n"
                                 + "2. Erase element\n"
                                 + "3. Calculate elements between leftBorder and rightBorder\n"
                                 + "4. How many elements bigger than your input element\n"
                                 + "5. Exit");

                int operation = getNumber(1, 5);
                int number;

                switch (operation)
                {
                    case 1:
                        Console.Write("Enter value which you need to add: ");
                        number = getNumber(0, int.MaxValue);
                        insert(number);
                        Console.WriteLine("Successfully added");
                        break;
                    case 2:
                        Console.Write("Enter value which you need to erase: ");
                        number = getNumber(0, int.MaxValue);
                        erase(number);
                        Console.WriteLine("Successfully deleted");
                        break;
                    case 3:
                        Console.Write("Enter left border: ");
                        int left = getNumber(0, int.MaxValue);
                        Console.Write("Enter right border: ");
                        int right = getNumber(left, int.MaxValue);
                        Console.WriteLine(getAmountBetween(left, right));
                        break;
                    case 4:
                        Console.Write("Enter value which you need to erase: ");
                        number = getNumber(0, int.MaxValue);
                        Console.WriteLine(getAmountBetween(number + 1, int.MaxValue));
                        break;
                    default:
                        return;
                }
            }
        }

        public static int getNumber(int left, int right)
        {
            while (true)
            {
                string data = Console.ReadLine();
                int result;
                if (int.TryParse(data, out result) == false || result < left || result > right)
                {
                    Console.Write(String.Format("Please enter the correct value between({0}, {1}): ", left.ToString(), right.ToString()));
                    continue;
                }
                return result;
            }
        }
    }
}
