using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; private set; }

        public string AddAnimal(Animal animal)
        {
            if (!Animals.Any())
            {
                if (string.IsNullOrEmpty(animal.Species))
                {
                    return "Invalid animal species.";
                }
                if (animal.Diet != "herbivore")
                {
                    if (animal.Diet != "carnivore")
                    {
                        return "Invalid animal diet.";
                    }
                }
                this.Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
            else if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore")
            {
                if (animal.Diet != "carnivore")
                {
                    return "Invalid animal diet.";
                }
            }
            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int count = 0;

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Species == species)
                {
                    this.Animals.Remove(Animals[i]);
                    i--;
                    count++;
                }
            }
            return count;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var targetDiet = this.Animals.FindAll(x => x.Diet == diet);
            return targetDiet;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var targetAnimal = this.Animals.FirstOrDefault(x => x.Weight == weight);
            if (targetAnimal == null)
            {
                return null;
            }
            return targetAnimal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var targetAnimals = this.Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength);
            return $"There are {targetAnimals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
