using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communalka.Modules
{
    public class Rates
    {
        public static double Heating { get; set; }
        public static double Water { get; set; }
        public static double Gas { get; set; }
        public static double Maintenance { get; set; }

        public Rates()
        {
          
        }

      

        public static void IncreaseRates(int value)
        {
            Heating += Heating * value / 100;
            Water += Water * value / 100;
            Gas += Gas * value / 100;
            Maintenance += Maintenance * value / 100;
        }
    }
}
