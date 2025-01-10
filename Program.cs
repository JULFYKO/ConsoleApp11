using System;

namespace FractionDemo
{
    struct Drib
    {
        public int Num { get; set; }
        public int Den { get; set; }

        public Drib(int num, int den)
        {
            if (den == 0)
            {
                Num = 0;
                Den = 1;
            }
            else
            {
                Num = num;
                Den = den;
                Normalize();
            }
        }

        private void Normalize()
        {
            int gcd = FindGCD(Math.Abs(Num), Math.Abs(Den));
            Num /= gcd;
            Den /= gcd;

            if (Den < 0)
            {
                Num = -Num;
                Den = -Den;
            }
        }

        private static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Drib operator +(Drib a, Drib b)
        {
            int num = a.Num * b.Den + b.Num * a.Den;
            int den = a.Den * b.Den;
            return new Drib(num, den);
        }

        public static Drib operator -(Drib a, Drib b)
        {
            int num = a.Num * b.Den - b.Num * a.Den;
            int den = a.Den * b.Den;
            return new Drib(num, den);
        }

        public static Drib operator *(Drib a, Drib b)
        {
            int num = a.Num * b.Num;
            int den = a.Den * b.Den;
            return new Drib(num, den);
        }

        public static Drib operator /(Drib a, Drib b)
        {
            if (b.Num == 0)
            {
                return new Drib(0, 1);
            }

            int num = a.Num * b.Den;
            int den = a.Den * b.Num;
            return new Drib(num, den);
        }

        public override string ToString()
        {
            return $"{Num}/{Den}";
        }

    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Drib f1 = new Drib(3, 4);
            Drib f2 = new Drib(2, 5);

            Console.WriteLine($"f1 = {f1}");
            Console.WriteLine($"f2 = {f2}");

            Console.WriteLine($"f1 + f2 = {f1 + f2}");
            Console.WriteLine($"f1 - f2 = {f1 - f2}");
            Console.WriteLine($"f1 * f2 = {f1 * f2}");
            Console.WriteLine($"f1 / f2 = {f1 / f2}");
        }
    }

}
