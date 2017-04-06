using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {  
        static void Main(string[] args)
        {
            int k = 0;
            int k2 = 0;
            int k3 = 0;
            Random rnd = new Random();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int[,] mas = new int[a, b];
            int[] sum = new int[a];
            int[] sum2 = new int[b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    mas[i,j] = rnd.Next(2);
                }
            }
            for (int i = 0; i < a; i++)
            {
                for(int j = 0; j < b; j++)
                {
                    sum[i] += mas[i, j];
                }
            }
            for (int i = 0; i < a; i++)
            {
                if (sum[i] != 1)
                {
                    k ++;
                }             
            }
            int[,] mas2 = new int[k, b];
            int p = 0;
            for(int i = 0; i < a ; i++)
            {
                if (sum[i] != 1)
                {
                    for (int j = 0; j < b; j++)
                    {
                        mas2[p, j] = mas[i, j];
                    }
                    p++;
                }
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(mas[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(mas2[i, j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    sum2[i] += mas2[j, i];
                }
            }
            for (int i = 0; i < b; i++)
            {
                if (sum2[i] != 1)
                {
                    k2++;
                }
            }
            int[,] mas3 = new int[k, k2];
            int p2 = 0;
            for (int i = 0; i < b; i++)
            {
                if (sum2[i] != 1)
                {
                    for (int j = 0; j < k; j++)
                    {
                        mas3[j, p2] = mas2[j, i];
                    }
                    p2++;
                }
            }
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k2; j++)
                {
                    Console.Write(mas3[i, j]);
                }
                Console.WriteLine();
            }
            int[] sum3 = new int[k];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k2; j++)
                {
                    sum3[i] += mas3[i, j];
                }
            }
            for (int i = 0; i < k; i++)
            {
                if (sum3[i] != 1)
                {
                    k3++;
                }
            }
            int[,] mas4 = new int[k3, k2];
            int p3 = 0;
            for (int i = 0; i < k; i++)
            {
                if (sum3[i] != 1)
                {
                    for (int j = 0; j < k2; j++)
                    {
                        mas4[p3, j] = mas3[i, j];
                    }
                    p3++;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < k3; i++)
            {
                for (int j = 0; j < k2; j++)
                {
                    Console.Write(mas4[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
