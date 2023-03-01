using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private Topping toppings;

        public Pizza(string name, Dough dough, Topping toppings)
        {
            Name = name;
            Dough = dough;
            Toppings = toppings;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }
        public Topping Toppings
        {
            get { return toppings; }
            private set { toppings = value; }
        }
    }
}
