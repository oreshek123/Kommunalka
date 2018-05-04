using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Communalka.Modules;

/*Написать программу, рассчитывающую сумму коммунальных платежей:
 есть базовые тарифы на отопление (на 1 м2 площади), на воду (на 1 чел),
 на газ (на 1 чел), на текущий ремонт (на 1 м2 площади). Задается метраж помещения, 
 количество проживающих людей, сезон (осенью и зимой отопление дороже), 
 наличие льгот (ветеран труда– 30 % от его части; ветеран войны- 50% от его части).
 Вывести таблицу со столбцами: Вид платежа, Начислено, Льготная скидка, Итого. 
 Посчитать итоговую сумму.*/

namespace Communalka
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Start

            int choice = 0, v, season, zhilplosh, people;
            do
            {
                Console.WriteLine("Какое сейчас время года? 1 - Лето 2 - Осень 3 - Зима 4 - Весна");
                int.TryParse(Console.ReadLine(), out season);
            } while (season < 1 || season > 4);

            Console.WriteLine("Введите количество квадратных метров вашего жилища");
            int.TryParse(Console.ReadLine(), out zhilplosh);

            Console.WriteLine("Введите количество людей, проживающих в вашем доме");
            int.TryParse(Console.ReadLine(), out people);

            do
            {
                Console.WriteLine("Вы ветеран? 1 - Да | 2 - Нет");
                int.TryParse(Console.ReadLine(), out v);
                if (v == 1)
                {
                    do
                    {
                        Console.WriteLine("Ветеран 1 - труда | 2 - войны");
                        int.TryParse(Console.ReadLine(), out choice); 
                    } while (choice < 1 || choice > 2);

                }
            } while (v < 1 || v > 2);

            if (v == 2) choice = 3;
            #endregion

            Person person = new Person(season,choice,people,zhilplosh);
            Service service = new Service();
            Service.GenerateRates(person);
            
            Console.Clear();
            service.ShowRates();
            do
            {
            Console.WriteLine("Выберите тип оплаты");
            Console.WriteLine("1 - За воду\n2 - За отопление\n3 - За газ\n4 - За расходы на содержание жилища");
            
            switch (Console.ReadLine())
            {
                case "1":
                {
                    service.CountPay(service,person, 2);
                    service.ShowAllPays(service,person);
                }
                    break;
                case "2":
                {
                    service.CountPay(service,person, 1);
                    service.ShowAllPays(service,person);
                }
                    break;
                case "3":
                {
                    service.CountPay(service,person, 3);
                    service.ShowAllPays(service,person);
                }
                    break;
                case "4":
                {
                    service.CountPay(service,person, 4);
                    service.ShowAllPays(service,person);
                    }
                    break;
                }
            } while (true);

            Console.ReadLine();
        }
    }
}
