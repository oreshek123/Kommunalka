using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Communalka.Modules
{
    public enum Season
    {
        Summer = 1, Autumn = 2, Winter = 3, Spring = 4
    }

    public enum Privileges
    {
        VeteranOfLabour = 1, WarVeteran = 2, No = 3
    }
    public class Person
    {
        public Season Seson { get; set; }
        
        public Privileges Privileges { get; set; }
        public int People { get; set; }
        public double Quantity { get; set; }
        
        public Person() { }
        public Person(int seson, int privileges,
            int people, double quantity)
        {
            Seson = (Season)seson;
            Privileges = (Privileges)privileges;
            People = people;
            Quantity = quantity;
            
        }

        

        public void ShowAllInfoAboutPerson()
        {
            Console.WriteLine($"season = {this.Seson.ToString()} privileges = {this.Privileges.ToString()} " +
                              $"people" +
                              $" = {this.People} quantity = {this.Quantity}");
        }
        

    }
   
   
}
