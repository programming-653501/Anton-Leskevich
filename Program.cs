using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {   static void help(int a)
        {
            switch (a)
            {
                case 1:
                    Console.Write("один");
                    break;
                case 2:
                    Console.Write("два");
                    break;
                case 3:
                    Console.Write("три");
                    break;
                case 4:
                    Console.Write("четыре");
                    break;
                case 5:
                    Console.Write("пять");
                    break;
                case 6:
                    Console.Write("шесть");
                    break;
                case 7:
                    Console.Write("семь");
                    break;
                case 8:
                    Console.Write("восемь");
                    break;
                case 9:
                    Console.Write("девять");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            string s = Console.ReadLine();
            int number = int.Parse(s);
            int ostatok2 = number % 10;
            int ostatok1 = (number - ostatok2) / 10;
            switch(ostatok1)
            {
                case 0:
                    help(ostatok2);
                    break;
                case 2:
                    Console.Write("двадцать ");
                    help(ostatok2);
                    break;
                case 3:
                    Console.Write("тридцать ");
                    help(ostatok2);
                    break;
                case 4:
                    Console.Write("сорок ");
                    help(ostatok2);
                    break;
                case 5:
                    Console.Write("пятьдесят ");
                    help(ostatok2);
                    break;
                case 6:
                    Console.Write("шестьдесят ");
                    help(ostatok2);
                    break;
                case 7:
                    Console.Write("семдесят ");
                    help(ostatok2);
                    break;
                case 8:
                    Console.Write("всемдесят ");
                    help(ostatok2);
                    break;
                case 9:
                    Console.Write("девяноста ");
                    help(ostatok2);
                    break;
                default:
                    switch (ostatok2)
                    {
                        case 0:
                            Console.Write("Десять");
                            break;
                        case 1:
                            Console.Write("Одинадцать");
                            break;
                        case 2:
                            Console.Write("Двенадцать");
                            break;
                        case 3:
                            Console.Write("Тринадцать");
                            break;
                        case 4:
                            Console.Write("Четрынадцать");
                            break;
                        case 5:
                            Console.Write("Пятнадцать");
                            break;
                        case 6:
                            Console.Write("Шестнадцать");
                            break;
                        case 7:
                            Console.Write("Семнадцать");
                            break;
                        case 8:
                            Console.Write("Восемнадцать");
                            break;
                        case 9:
                            Console.Write("Девятнадцать");
                            break;
                    }
                    break;


            }



            Console.ReadKey();
        }
    }
}
