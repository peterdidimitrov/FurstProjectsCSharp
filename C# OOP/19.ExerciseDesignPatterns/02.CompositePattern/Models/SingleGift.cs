using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");
            return price;
        }
    }
}
