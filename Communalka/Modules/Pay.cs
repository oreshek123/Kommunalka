using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communalka.Modules
{
   
    public class Pay
    {
        public string Name { get; set; }
        
        private int _typeOfPay;
        public int TypeOfPay
        {
            get => _typeOfPay;
            set
            {
                if (value < 1 || value > 4)
                    throw new Exception("Неверный тип операции");
                else _typeOfPay = value;
            }
        }
        public double Nachisleno { get; set; }
        public double Total { get; set; }

        public Pay(int typeOfPay)
        {
            TypeOfPay = typeOfPay;
        }

        
    }
}
