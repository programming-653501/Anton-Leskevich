using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class AirComfort
    {       
        public int numberofwindws;
        public int numberofbalconies;
        public int floor;
        public void illustration()
        {
            Console.WriteLine("Общая площдь застекления {0}, стоимость 1 оконного пакета равна 100$, одной балконной двери - 150$, если квартира выше первого этажа , за каждый стеклопакет надбавка 15%", (2.15*1.5*numberofwindws) + (0.7*2.5*numberofbalconies));
        }
        public void price()
        {
            if (floor > 1)
            {
                Console.WriteLine("Общая стоимость проекта {0}",numberofwindws * 100 * 1.15 + 150 * numberofbalconies);
            }
            else Console.WriteLine("Общая стоимость проекта {0}", numberofwindws * 100 + 150 * numberofbalconies);
        }
        public void information()
        {
            Console.WriteLine("Офис находится по адресу ул.Евфросиньи Полоцкой 1 / 118, офис. 1, г.Минск, Республика Беларусь");
        }

    }
}
