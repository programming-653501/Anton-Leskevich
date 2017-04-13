using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 0;
            string list = @"C:\C\list.txt";
            try
            {
                using (StreamReader sr = new StreamReader(list, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        amount++;
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(amount);
            string[] mas2 = new string[amount];
            try
            {
                using (StreamReader sr = new StreamReader(list, System.Text.Encoding.Default))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        mas2[i] = line;
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Array.Sort(mas2);
            string[,] result = new string[amount, 3];
            for (int i = 0; i < amount; i++)
            {
                string[] words = mas2[i].Split(new char[] { ' ' });
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = words[j];
                }
            }
            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = result[i, j].Substring(0, 1).ToUpper() + result[i, j].Remove(0, 1);
                }
            }

            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }





            Console.ReadKey();
        }
    }
}
