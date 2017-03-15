using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество окон, балконных дверей и эттаж");
            AirComfort a1 = new AirComfort();
            a1.numberofwindws = int.Parse(Console.ReadLine());
            a1.numberofbalconies = int.Parse(Console.ReadLine());
            a1.floor = int.Parse(Console.ReadLine());
            a1.illustration();
            a1.price();
            a1.information();
            Console.ReadKey();
        }
    }
}
