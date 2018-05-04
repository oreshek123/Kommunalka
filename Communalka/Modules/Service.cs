using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communalka.Modules
{
    class Service
    {
        public List<Pay> Pays { get; set; }
        private string[] name_ = new[] { "За отопление", "За воду", "За газ", "За содержание жилища" };

        public Service()
        {
            Pays = new List<Pay>();
        }

        public Pay this[int i]
        {
            get { return Pays[i]; }
        }
        public void ShowAllPays(Service service, Person person)
        {
            string vidop = "Вид оплаты";
            string nach = "Начислено";
            string lgoty = "Льготы";
            string itog = "Итого";
            Console.WriteLine("{0,20} | {1,20} | {2,20} | {3,20}",vidop,nach,lgoty,itog ); 
            double sum = 0;
          
            for (int i = 0; i < Pays.Count; i++)
            {
                Console.WriteLine(service.ShowPay(person,service[i]));
                sum += service[i].Total;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t Итого к оплате : {sum}");
            Console.ResetColor();
        }
        public void CountPay(Service service , Person person, int typeOfPay)
        {
            Pay pay = new Pay(typeOfPay);
            if (pay.TypeOfPay == 1)
            {
                pay.Nachisleno = person.Quantity * Rates.Heating;
                pay.Name = name_[0];
            }
            else if (pay.TypeOfPay == 2)
            {
                pay.Nachisleno = person.People * Rates.Water;
                pay.Name = name_[1];
            }
            else if (pay.TypeOfPay == 3)
            {
                pay.Nachisleno = person.People * Rates.Gas;
                pay.Name = name_[2];
            }
            else if (pay.TypeOfPay == 4)
            {
                pay.Nachisleno = person.Quantity * Rates.Maintenance;
                pay.Name = name_[3];
            }

            if (person.Privileges == (Privileges)1)
            {
                pay.Total = pay.Nachisleno - (pay.Nachisleno * 30 / 100);
            }
            else if (person.Privileges == (Privileges)2)
            {
                pay.Total = pay.Nachisleno - (pay.Nachisleno * 50 / 100);
            }
            else if (person.Privileges == (Privileges)3)
            {
                pay.Total = pay.Nachisleno;
            }


            service.Pays.Add(pay);
        }
        public string ShowPay(Person person, Pay pay)
        {
            string privileges = "";
            if (person.Privileges == (Privileges)1)
            {
                privileges += "30 %";
            }
            else if (person.Privileges == (Privileges)2)
            {
                privileges += "50 %";
            }
            else if (person.Privileges == (Privileges)3)
                privileges += "0 %";

            return string.Format("{0,20} | {1,20} | {2,20} | {3,20} ",pay.Name,pay.Nachisleno,privileges,pay.Total);
        }






        public static void GenerateRates(Person person)
        {

            Random random = new Random();
            Rates.Heating = random.Next(100, 300);
            Rates.Gas = random.Next(50, 200);
            Rates.Water = random.Next(100, 200);
            Rates.Maintenance = random.Next(300, 500);

            if (person.Seson == (Season)2 || person.Seson == (Season)3)
                Rates.IncreaseRates(5);

        }
        public void ShowRates()
        {
            Console.WriteLine($"\n\nТариф на отопление {Rates.Heating}\tТариф на воду {Rates.Water}\tТариф на газ {Rates.Gas}\tТариф на текущий ремонт {Rates.Maintenance}");
        }

    }
}
