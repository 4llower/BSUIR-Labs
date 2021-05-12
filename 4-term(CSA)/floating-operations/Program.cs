using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ABC
{
    public static class FloatExtension
    {
        public static Real ToReal(this float f)
        {
            return new Real(f);
        }
    }
    public static class LongExtension
    {
        public static long RoundedDivision(this long a, long b)
        {
            bool aneg = a < 0;
            if (aneg)
            {
                a = -a;
            }
            bool bneg = b < 0;
            if (bneg)
            {
                b = -b;
            }
            long sign = aneg != bneg ? -1 : 1;
            long q = a / b;
            if ((a % b) * 2 > b)
            {
                q++;
            }
            return sign * q;
        }
    }


    public class Real
    {
        public long Sign = 0;
        public long Exp = 0;
        public long Mant = 0;

        public static long MantSecret => 1 << 23;
        public static long ExpSecret => 127;
        public static float Smallest => new Real(0, 1 - ExpSecret, MantSecret).ToFloat();
        public static float Biggest => new Real(0, ExpSecret, 2 * MantSecret - 1).ToFloat();

        public Real(float x)
        {
            string s = Convert.ToString(BitConverter.SingleToInt32Bits(x), 2).PadLeft(32, '0');
            Sign = Convert.ToInt32(s.Substring(0, 1), 2);
            Exp = Convert.ToInt32(s.Substring(1, 8), 2);
            Mant = Convert.ToInt32(s.Substring(9, 23), 2);
        }
        public Real(string s)
        {
            Sign = Convert.ToInt32(s.Substring(0, 1), 2);
            Exp = Convert.ToInt32(s.Substring(1, 8), 2);
            Mant = Convert.ToInt32(s.Substring(9, 23), 2);
        }
        public Real(long fullsign, long fullexp, long fullmant)
        {
            Sign = fullsign < 0 ? 1 : 0;
            Exp = fullexp + ExpSecret;
            Mant = fullmant - MantSecret;
        }

        public override string ToString()
        {
            return
                Convert.ToString(Sign, 2).PadLeft(1, '0') +
                Convert.ToString(Exp, 2).PadLeft(8, '0') +
                Convert.ToString(Mant, 2).PadLeft(23, '0');
        }
        public string ToFormat()
        {
            return ToString().Insert(9, " ").Insert(1, " ");
        }
        public float ToFloat()
        {
            return BitConverter.Int32BitsToSingle(Convert.ToInt32(ToString(), 2));
        }
        public bool EqualsZero()
        {
            return Exp == 0 && Mant == 0;
        }
    }

    static class ABC456
    {
        public static void Add(Real a, Real b)
        {
            Console.WriteLine();
            Console.WriteLine("ADDITION");
            Console.WriteLine("--------");
            Console.WriteLine("First number =  " + a.ToFloat());
            Console.WriteLine("Second number = " + b.ToFloat());
            Console.WriteLine();
            Console.WriteLine("In two's complement:");
            Console.WriteLine("First number =  " + a.ToFormat());
            Console.WriteLine("Second number = " + b.ToFormat());
            Console.WriteLine();

            long SignA = (a.Sign == 1 ? -1 : 1), SignB = (b.Sign == 1 ? -1 : 1);
            long ExpA = a.Exp - Real.ExpSecret, ExpB = b.Exp - Real.ExpSecret;
            long MantA = a.Mant + Real.MantSecret, MantB = b.Mant + Real.MantSecret;

            if (a.EqualsZero() || b.EqualsZero()) { 
                Real s = a.EqualsZero() ? b : a;
                Console.WriteLine("One of the numbers equals zero:");
                Console.WriteLine("Summ = " + s.ToFormat());
                Console.WriteLine("Summ = " + s.ToFloat());
                return;
            }

            while (ExpA < ExpB)
            {
                ExpA++;
                MantA >>= 1;
            }
            while (ExpB < ExpA)
            {
                ExpB++;
                MantB >>= 1;
            }
            Console.WriteLine("After normalization:");
            Console.WriteLine("First number =  " + a.ToFormat());
            Console.WriteLine("Second number = " + b.ToFormat());
            Console.WriteLine();
            if (MantA == 0 || MantB == 0)
            {
                Real s = MantA == 0 ? b : a;
                Console.WriteLine("One of the numbers is almost zero:");
                Console.WriteLine("Summ = " + s.ToFormat());
                Console.WriteLine("Summ = " + s.ToFloat());
                return;
            }

            long ExpS = ExpA;
            long MantS = MantA * SignA + MantB * SignB;
            long SignS = (MantS < 0 ? -1 : 1);
            MantS *= SignS;

            if (MantS == 0)
            {
                Real s = new Real(0.0f);
                Console.WriteLine("Summ of the numbers is zero:");
                Console.WriteLine("Summ = " + s.ToFormat());
                Console.WriteLine("Summ = " + s.ToFloat());
                return;
            }

            while (MantS >= (Real.MantSecret << 1))
            {
                MantS >>= 1;
                ExpS++;
            }
            while (MantS < (1 << 23))
            {
                MantS <<= 1;
                ExpS--;
            }
            if (ExpS <= -Real.ExpSecret)
            {
                Console.WriteLine("UNDERFLOW!");
                return;
            }
            if (Real.ExpSecret < ExpS)
            {
                Console.WriteLine("OVERFLOW!");
                return;
            }

            Real S = new Real(SignS, ExpS, MantS);
            Console.WriteLine("Summ = " + S.ToFormat());
            Console.WriteLine("Summ = " + S.ToFloat());
        }
        public static void Add(float a, float b)
        {
            Add(a.ToReal(), b.ToReal());
        }
        
        public static void Sub(Real a, Real b)
        {
            Console.WriteLine();
            Console.WriteLine("SUBTRACTION");
            Console.WriteLine("--------");
            Console.WriteLine("First number =  " + a.ToFloat());
            Console.WriteLine("Second number = " + b.ToFloat());
            Console.WriteLine();
            Console.WriteLine("In two's complement:");
            Console.WriteLine("First number = " + a.ToFormat());
            Console.WriteLine("Second number = " + b.ToFormat());
            b.Sign = (b.Sign != 0) ? 0 : 1;
            Console.WriteLine("Negate second number:");
            Console.WriteLine("Second number = " + b.ToFloat());
            Console.WriteLine("Second number = " + b.ToFormat());
            Add(a, b);
        }
        public static void Sub(float a, float b)
        {
            Sub(a.ToReal(), b.ToReal());
        }
        
        public static void Mul(Real a, Real b)
        {
            Console.WriteLine();
            Console.WriteLine("MULTIPLICATION");
            Console.WriteLine("--------");
            Console.WriteLine("First number =  " + a.ToFloat());
            Console.WriteLine("Second number = " + b.ToFloat());
            Console.WriteLine();
            Console.WriteLine("In two's complement:");
            Console.WriteLine("First number =  " + a.ToFormat());
            Console.WriteLine("Second number = " + b.ToFormat());
            Console.WriteLine();

            long SignA = (a.Sign == 1 ? -1 : 1), SignB = (b.Sign == 1 ? -1 : 1);
            long ExpA = a.Exp - Real.ExpSecret, ExpB = b.Exp - Real.ExpSecret;
            long MantA = a.Mant + Real.MantSecret, MantB = b.Mant + Real.MantSecret;

            if (a.EqualsZero() || b.EqualsZero())
            {
                Real s = new Real(0.0f);
                Console.WriteLine("One of the numbers equals zero:");
                Console.WriteLine("Product = " + s.ToFormat());
                Console.WriteLine("Product = " + s.ToFloat());
                return;
            }

            long SignP = SignA != SignB ? -1 : 1;
            long ExpP = ExpA + ExpB;
            long MantP = (MantA * MantB).RoundedDivision(Real.MantSecret);

            while (MantP >= (Real.MantSecret << 1))
            {
                MantP >>= 1;
                ExpP++;
            }
            while (MantP < (1 << 23))
            {
                MantP <<= 1;
                ExpP--;
            }
            if (ExpP <= -Real.ExpSecret)
            {
                Console.WriteLine("UNDERFLOW!");
                return;
            }
            if (Real.ExpSecret < ExpP)
            {
                Console.WriteLine("OVERFLOW!");
                return;
            }

            Real P = new Real(SignP, ExpP, MantP);
            Console.WriteLine("Product = " + P.ToFormat());
            Console.WriteLine("Product = " + P.ToFloat());
        }
        public static void Mul(float a, float b)
        {
            Mul(a.ToReal(), b.ToReal());
        }
        
        public static void Div(Real a, Real b)
        {
            Console.WriteLine();
            Console.WriteLine("DIVISION");
            Console.WriteLine("--------");
            Console.WriteLine("First number =  " + a.ToFloat());
            Console.WriteLine("Second number = " + b.ToFloat());
            Console.WriteLine();
            Console.WriteLine("In two's complement:");
            Console.WriteLine("First number =  " + a.ToFormat());
            Console.WriteLine("Second number = " + b.ToFormat());
            Console.WriteLine();

            long SignA = (a.Sign == 1 ? -1 : 1), SignB = (b.Sign == 1 ? -1 : 1);
            long ExpA = a.Exp - Real.ExpSecret, ExpB = b.Exp - Real.ExpSecret;
            long MantA = a.Mant + Real.MantSecret, MantB = b.Mant + Real.MantSecret;

            if (b.EqualsZero())
            {
                Console.WriteLine("ZERO DIVISION!");
                return;
            }

            if (a.EqualsZero())
            {
                Real s = new Real(0.0f);
                Console.WriteLine("First number equals zero:");
                Console.WriteLine("Product = " + s.ToFormat());
                Console.WriteLine("Product = " + s.ToFloat());
                return;
            }

            long SignQ = SignA != SignB ? -1 : 1;
            long ExpQ = ExpA - ExpB;
            long MantQ = (MantA * Real.MantSecret).RoundedDivision(MantB);

            while (MantQ >= (Real.MantSecret << 1))
            {
                MantQ >>= 1;
                ExpQ++;
            }
            while (MantQ < (1 << 23))
            {
                MantQ <<= 1;
                ExpQ--;
            }
            if (ExpQ <= -Real.ExpSecret)
            {
                Console.WriteLine("UNDERFLOW!");
                return;
            }
            if (Real.ExpSecret < ExpQ)
            {
                Console.WriteLine("OVERFLOW!");
                return;
            }

            Real Q = new Real(SignQ, ExpQ, MantQ);
            Console.WriteLine("Quotient = " + Q.ToFormat());
            Console.WriteLine("Quotient = " + Q.ToFloat());
        }
        public static void Div(float a, float b)
        {
            Div(a.ToReal(), b.ToReal());
        }
        
        public static void TestAdd()
        {
            Add(-321.0f, 123.0f);
            Add(100.0f, 0.0f);
            Add(0.1f, Real.Smallest);
            Add(0.5f * Real.Biggest, 0.6f * Real.Biggest);
        }
        public static void TestSub()
        {
            Sub(100.0f, 100.0f);
            Sub(5.5f * Real.Smallest, 5.0f * Real.Smallest);
        }
        public static void TestMul()
        {
            Mul(123.0f, -0.321f);
            Mul(1.0f, 0.0f);
            Mul(Real.Biggest, Real.Smallest);
            Mul(Real.Biggest, 1.1f);
            Mul(Real.Smallest, 0.9f);
        }
        public static void TestDiv()
        {
            Div(321, -123);
            Div(0, 100);
            Div(1, 0);
            Div(Real.Biggest, 0.9f);
            Div(Real.Smallest, 1.1f);
        }
        
    }

    static class Program
    {
        static void Main(string[] args)
        {
            //ABC456.TestAdd(); Console.WriteLine();
            //ABC456.TestSub(); Console.WriteLine();
            //ABC456.TestMul(); Console.WriteLine();
            //ABC456.TestDiv(); Console.WriteLine();

            Console.WriteLine("Input first number:");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Input second number:");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("Input operation: a / s / m / d");
            char oper = (char)Console.Read();
            switch (oper)
            {
                case 'a':
                    ABC456.Add(a, b);
                    break;
                case 's':
                    ABC456.Sub(a, b);
                    break;
                case 'm':
                    ABC456.Mul(a, b);
                    break;
                case 'd':
                    ABC456.Div(a, b);
                    break;
            }
        }
    }
}