using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int ag, string group)
        {
            Name = name;
            Ag = ag;
            Group = group;
        }

        public string Name { get; private set; }
        public int Ag { get; private set; }
        public string Group { get; private set; }

        public int Food { get; private set; }

        public int Buy() => Food += 5;

    }
}
