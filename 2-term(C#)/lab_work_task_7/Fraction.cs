using System;
using System.Text.RegularExpressions;

namespace lab_work_7
{
    public class Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        public int Numerator { get; set; } // Numerator - whole number

        public int Denominator { get; set; } // Denominator - natural number

        /* constructors */
        public Fraction(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            RecalcParameters();
        }

        public Fraction(double irrational)
        {
            Fraction fraction = Parse(irrational.ToString());
            Numerator = fraction.Numerator;
            Denominator = fraction.Denominator;
        }

        /* help methods */

        private void RecalcParameters()
        {
            bool needToNegative = (Numerator < 0);
            Numerator *= -1 * (needToNegative ? 1 : -1);

            int gcd = GCD(Numerator, Denominator);

            Numerator /= gcd;
            Denominator /= gcd;

            Numerator *= (-1 * (needToNegative ? 1 : -1));

        }

        public static Fraction Parse(string input)
        {

            Regex format1Pattern = new Regex("[\\+\\-]?[0-9]+[.,][0-9]+"); // XX.YY
            Regex format2Pattern = new Regex("[\\+\\-]?[0-9]+\\/[0-9]+"); // XX/YY
            Regex format3Pattern = new Regex("[\\+\\-]?[0-9]+"); // XX
            input += " ";

            if (format1Pattern.IsMatch(input))
            {
                MatchCollection matches = format1Pattern.Matches(input);

                if (matches.Count > 1)
                {
                    throw new FormatException("So many fractions in string:(");
                }

                string recieved = matches[0].Value;
                char sym = (recieved.IndexOf('.') != -1 ? '.' : ',');
                string numeratorString = recieved.Substring(0, recieved.IndexOf(sym)) + recieved.Substring(recieved.IndexOf(sym) + 1);

                int numerator = int.Parse(numeratorString);
                int denominator = Pow(10, numeratorString.Length - 1);

                return new Fraction(numerator, denominator);
            }

            if (format2Pattern.IsMatch(input))
            {
                MatchCollection matches = format2Pattern.Matches(input);

                if (matches.Count > 1)
                {
                    throw new FormatException("So many fractions in string:(");
                }

                string recieved = matches[0].Value;
                string numeratorString = recieved.Substring(0, recieved.IndexOf('/'));
                string denominatorString = recieved.Substring(recieved.IndexOf('/') + 1);

                int numerator = int.Parse(numeratorString);
                int denominator = int.Parse(denominatorString);

                return new Fraction(numerator, denominator);
            }

            if (format3Pattern.IsMatch(input))
            {
                MatchCollection matches = format3Pattern.Matches(input);

                if (matches.Count > 1)
                {
                    throw new FormatException("So many fractions in string:(");
                }

                string recieved = matches[0].Value;

                int numerator = int.Parse(recieved);
                int denominator = 1;

                return new Fraction(numerator, denominator);
            }

            throw new FormatException("This string is incorrect for convert to fraction:(");
        }

        public override string ToString()
        {
            return ToString();
        }

        public string ToString(string format = "XX/YY")
        {
            string result;

            switch (format)
            {
                case "XX":
                    result = ((int)this).ToString();
                    break;
                case "XX.YY":
                    result = ((double)this).ToString();
                    break;
                case "XX/YY":
                    result = Numerator.ToString() + "/" + Denominator.ToString();
                    break;
                default:
                    throw new FormatException(string.Format("This format is not supported({0}).", format));
            }

            return result;
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a >= b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }

        private static int Pow(int a, int b)
        {
            int result = 1;
            while (b != 0)
            {
                result *= a;
                b--;
            }
            return result;
        }

        private static int LCM(int a, int b)
        {
            return (a * b) / GCD(a, b);
        }

        /* operators for `Fraction` + implicit operators from ... to Fraction*/

        public static Fraction operator +(Fraction left, Fraction right)
        {

            int newDenominator = LCM(left.Denominator, right.Denominator);
            int newNumerator = 0;

            newNumerator += (left.Numerator * (newDenominator / left.Denominator));
            newNumerator += (right.Numerator * (newDenominator / right.Denominator));

            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            int newDenominator = LCM(left.Denominator, right.Denominator);
            int newNumerator = 0;

            newNumerator += (left.Numerator * (newDenominator / left.Denominator));
            newNumerator -= (right.Numerator * (newDenominator / right.Denominator));

            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            int newNumerator = left.Numerator * right.Numerator;
            int newDenominator = left.Denominator * right.Denominator;
            if (newDenominator < 0)
            {
                newDenominator *= -1;
                newNumerator *= -1;
            }
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            int newNumerator = left.Numerator * right.Denominator;
            int newDenominator = left.Denominator * right.Numerator;
            if (newDenominator < 0)
            {
                newDenominator *= -1;
                newNumerator *= -1;
            }
            return new Fraction(newNumerator, newDenominator);
        }

        public static bool operator <=(Fraction left, Fraction right)
        {
            return left.Compare(right) != 1;
        }

        public static bool operator >=(Fraction left, Fraction right)
        {
            return left.Compare(right) != -1;
        }

        public static bool operator <(Fraction left, Fraction right)
        {
            return left.Compare(right) == -1;
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            return left.Compare(right) == 1;
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            return left.Compare(right) == 0;
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return left.Compare(right) != 0;
        }

        public static Fraction operator ++(Fraction fraction)
        {
            return (fraction + new Fraction(1));
        }

        public static Fraction operator --(Fraction fraction)
        {
            return (fraction - new Fraction(1));
        }

        public static bool operator true(Fraction fraction)
        {
            return (fraction.Numerator != 0);
        }

        public static bool operator false(Fraction fraction)
        {
            return (fraction.Numerator == 0);
        }

        public static implicit operator Fraction(int number)
        {
            return new Fraction(number);
        }

        public static implicit operator Fraction(double irrational)
        {
            return new Fraction(irrational);
        }

        /* operators for `int`*/
        public static Fraction operator +(Fraction left, int right)
        {
            return (left + new Fraction(right));
        }

        public static Fraction operator -(Fraction left, int right)
        {
            return (left - new Fraction(right));
        }

        public static Fraction operator *(Fraction left, int right)
        {
            return (left * new Fraction(right));
        }

        public static Fraction operator /(Fraction left, int right)
        {
            return (left * new Fraction(right));
        }

        public static explicit operator int(Fraction fraction)
        {
            return fraction.Numerator / fraction.Denominator;
        }

        /* operators for `double`*/

        public static Fraction operator +(Fraction left, double right)
        {
            return (left + new Fraction(right));
        }

        public static Fraction operator -(Fraction left, double right)
        {
            return (left - new Fraction(right));
        }

        public static Fraction operator *(Fraction left, double right)
        {
            return (left * new Fraction(right));
        }

        public static Fraction operator /(Fraction left, double right)
        {
            return (left / new Fraction(right));
        }

        public static explicit operator double(Fraction fraction)
        {
            return (fraction.Numerator + 0.0) / fraction.Denominator;
        }

        /* comparable and equable */

        private int Compare(Fraction other)
        {
            if (other.Numerator == 0 && Numerator == 0)
            {
                return 0;
            }

            if (other.Numerator == 0)
            {
                return (Numerator != 0 ? 1 : -1);
            }
            Fraction divResult = this / other;
            return divResult.Numerator.CompareTo(divResult.Denominator);
        }

        int IComparable<Fraction>.CompareTo(Fraction other)
        {
            return Compare(other);
        }

        public override bool Equals(object obj)
        {
            return Compare(obj as Fraction) == 0;
        }
        bool IEquatable<Fraction>.Equals(Fraction other)
        {
            return Compare(other) == 0;
        }
        public override int GetHashCode()
        {
            int hashCode = -3233;
            hashCode = hashCode * -1221 + Numerator.GetHashCode();
            hashCode = hashCode * -121 + Denominator.GetHashCode();
            return hashCode;
        }
    }
}
