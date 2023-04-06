using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }


            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var desiredAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if ((fish.GetType().Name == "FreshwaterFish" && desiredAquarium.GetType().Name == "SaltwaterAquarium") || (fish.GetType().Name == "SaltwaterFish" && desiredAquarium.GetType().Name == "FreshwaterAquarium"))
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }

            desiredAquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var desiredAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var result = desiredAquarium.Fish.Sum(f => f.Price) + desiredAquarium.Decorations.Sum(d => d.Price);

            return $"The value of Aquarium {aquariumName} is {result:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var desiredAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            desiredAquarium.Feed();

            return string.Format(OutputMessages.FishFed, desiredAquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var desiredDecoration = decorations.FindByType(decorationType);
            var desiredAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (desiredDecoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            desiredAquarium.AddDecoration(desiredDecoration);
            decorations.Remove(desiredDecoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var builder = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                builder.AppendLine(aquarium.GetInfo());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
