using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }
                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            { capacity = value; }
        }


        public int Comfort => decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration) => decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (Capacity == Fish.Count)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }
            Fish.Add(fish);
        }

        public void Feed() => fish.ForEach(f => f.Eat());
        public string GetInfo()
        {
            Type type = typeof(IAquarium);
            var builder = new StringBuilder();
            builder.AppendLine($"{Name} ({type}):");
            if (fish.Count == 0)
            {
                builder.AppendLine("none");
            }
            else
            {
                List<string> fishNames = new List<string>();
                foreach (var fish in Fish)
                {
                    fishNames.Add(fish.Name);
                }
                builder.AppendLine(string.Join(", ", fishNames));
                builder.AppendLine($"Decorations: {decorations.Count}");
                builder.AppendLine($"Comfort: {Comfort}");
            }

            return builder.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => Fish.Remove(fish);
    }
}
