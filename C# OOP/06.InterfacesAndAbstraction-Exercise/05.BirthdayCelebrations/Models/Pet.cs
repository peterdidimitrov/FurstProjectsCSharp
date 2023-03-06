using BirthdayCelebrations.Models.ICallable;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBorn
    {
        public Pet(string name, string date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; private set; }
        public string Date { get; private set; }

    }
}
