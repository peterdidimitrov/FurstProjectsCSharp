﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameExceptionMessage);
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
                    throw new ArgumentException(ExceptionMessages.MoneyExeptionMessage);
                }
                money = value;
            }
        }
        public override string ToString()
        {
            string productsToString = products.Any()
                ? string.Join(", ", products)
                : "Nothing bought";

            return $"{Name} - {productsToString}";
        }
        public string AddProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                products.Add(product);
                Money -= product.Cost;
                return $"{Name} bought {product}";
            }
            return $"{Name} can't afford {product}";
        }
    }
}
