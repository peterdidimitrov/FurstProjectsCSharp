using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = fish;
            Fish = new List<Fish>();
        }

        public string Material { get; private set; }
        public int Capacity { get; private set; }
        public List<Fish> Fish { get; set; }

        public int Count => Fish.Count;


        public string AddFish(Fish fish)
        {
            if (!Fish.Any())
            {
                if (string.IsNullOrEmpty(fish.FishType) ||
                    fish.Length <= 0 || fish.Weight <= 0)
                {
                    return "Invalid fish.";
                }
                this.Fish.Add(fish);
            }
            else if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }
            else if (Fish.Any())
            {
                if (string.IsNullOrEmpty(fish.FishType) ||
                    fish.Length <= 0 || fish.Weight <= 0)
                {
                    return "Invalid fish.";
                }
                this.Fish.Add(fish);
            }
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(e => e.Weight == weight);
            if (fish != null)
            {
                return this.Fish.Remove(fish);
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            var fish = this.Fish.FirstOrDefault(e => e.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            var targetFish = this.Fish.OrderByDescending(x => x.Length).First();
            if (targetFish == null)
            {
                return null;
            }
            return targetFish;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in this.Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
