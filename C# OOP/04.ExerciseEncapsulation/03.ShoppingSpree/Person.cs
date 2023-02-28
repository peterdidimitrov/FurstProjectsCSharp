using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                }
                money = value; 
            }
        }
        public bool BuyProduct(Person person)
        {
            if (person.money)
            {

            }
            return 
        }
    }
}
