using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Bag();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;

        public IBag Bag { get => bag; }

        public virtual void Breath()
        {
            Oxygen -= 10;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");

            string itemsInfo = Bag.Items.Any() ? string.Join(", ", Bag.Items) : "none";
            sb.AppendLine($"Bag items: {itemsInfo}");

            return sb.ToString().TrimEnd();
        }
    }
}
