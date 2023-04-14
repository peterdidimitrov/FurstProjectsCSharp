using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            IsReserved = false;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber
        {
            get { return tableNumber; }
            private set { tableNumber = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value; }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value; }
        }

        public decimal PricePerPerson
        {
            get { return pricePerPerson; }
            private set
            { pricePerPerson = value; }
        }

        public bool IsReserved { get; set; }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
            IsReserved = false;
            numberOfPeople = default;
        }

        public decimal GetBill() => drinkOrders.Sum(d => d.Price) + foodOrders.Sum(f => f.Price) + Price;

        public string GetFreeTableInfo()
        {
            Type type = GetType();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {type.Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {this.pricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
