using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private int load;
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Load
        {
            get { return load; }
            set { load = value; }
        }

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            var desiredItem = items.FirstOrDefault(i => i.GetType().Name == name);
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (desiredItem == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }
            items.Remove(desiredItem);
            return desiredItem;
        }
    }
}
