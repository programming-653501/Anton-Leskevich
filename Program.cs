using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._6
{
    class Program
    {
        static long Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        static void Main(string[] args)
        {
            double epsilon = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double S1 = Math.Sin(x);
            double S2 = 0, result = 0;
            for (int i=1; ; i++)
            {
                S2 += Math.Pow((-1), (i + 1)) * Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1);
                Console.WriteLine("sin(x)={0}, если по рекурсивной функции {1}", S1, S2);
                if (Math.Abs(S1 - S2) > epsilon)
                {
                    result = i;
                }
                else break;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}