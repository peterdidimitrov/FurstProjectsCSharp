using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Bag : IBag
    {
        private List<string> items;
        public Bag()
        {
            items = new List<string>();
        }
        public ICollection<string> Items => items;
    }
}
