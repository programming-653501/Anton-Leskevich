using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, e=0, y=0, u=0, i=0, o = 0;
            string text = Console.ReadLine();
            text = text.ToLower();
            int length = text.Length;
            for (int j = 0; j < length; j++)
            {
                if (text[j] == 'a') { a++; }
                if (text[j] == 'e') { e++; }
                if (text[j] == 'y') { y++; }
                if (text[j] == 'u') { u++; }
                if (text[j] == 'i') { i++; }
                if (text[j] == 'o') { o++; }
            }
            string [][] result = new string [7][];
            result[0] = new string[a+1];
            result[1] = new string[e+1];
            result[2] = new string[y+1];
            result[3] = new string[u+1];
            result[4] = new string[i+1];
            result[5] = new string[o+1];
            result[6] = new string[length-a-e-y-u-i-o+1];
            result[0][0] = "a   ";
            result[1][0] = "e   ";
            result[2][0] = "y   ";
            result[3][0] = "u   ";
            result[4][0] = "i   ";
            result[5][0] = "o   ";
            result[6][0] = "else";
            int k;
            for (k =1; k < a + 1; k++)
            {
                result[0][k] = "-";
            }
            for (k = 1; k < e + 1; k++)
            {
                result[1][k] = "-";
            }
            for (k = 1; k < y + 1; k++)
            {
                result[2][k] = "-";
            }
            for (k = 1; k < u + 1; k++)
            {
                result[3][k] = "-";
            }
            for (k = 1; k < i + 1; k++)
            {
                result[4][k] = "-";
            }
            for (k = 1; k < o + 1; k++)
            {
                result[5][k] = "-";
            }
            for (k = 1; k < length - a - e - y - u - i - o + 1; k++)
            {
                result[6][k] = "-";
            }
            for (k = 0; k < a + 1; k++)
            {
                Console.Write(result[0][k] + " ");
            }
            Console.WriteLine();
            for (k = 0; k < e + 1; k++)
            {
                Console.Write(result[1][k] + " ");
            }
            Console.WriteLine();
            for (k = 0; k < y + 1; k++)
            {
                Console.Write(result[2][k] + " ");
            }
            Console.WriteLine();
            for (k = 0; k < u + 1; k++)
            {
                Console.Write(result[3][k] + " ");
            }
            Console.WriteLine();
            for (k = 0; k < i + 1; k++)
            {
                Console.Write(result[4][k] + " ");
            }
            Console.WriteLine();
            for (k = 0; k < o + 1; k++)
            {
                Console.Write(result[5][k] + " ");
            }
            Console.WriteLine();
            for (k = 0; k < length - a - e - y - u - i - o + 1; k++)
            {
                Console.Write(result[6][k] + " ");
            }
            Console.ReadKey();
        }
    }
}
