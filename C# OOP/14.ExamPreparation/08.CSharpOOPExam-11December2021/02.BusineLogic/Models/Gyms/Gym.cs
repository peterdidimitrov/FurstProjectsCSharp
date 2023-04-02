using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }
        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight => equipments.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }
        public void AddEquipment(IEquipment equipment) => equipments.Add(equipment);

        public void Exercise() => athletes.ForEach(a => a.Exercise());

        public string GymInfo()
        {
            Type type = GetType();

            string[] typeOfGym = type.ToString().Split(".").TakeLast(1).ToArray();

            List<string> names = new List<string>();

            foreach (var athlete in athletes)
            {
                names.Add(athlete.FullName);
            }

            var builder = new StringBuilder();

            builder.AppendLine($"{Name} is a {typeOfGym[0]}:");
            if (names.Count == 0)
            {
                builder.AppendLine("Athletes: No athletes");
            }
            else
            {
                builder.AppendLine($"Athletes: {string.Join(", ", names)}");
            }
            builder.AppendLine($"Equipment total count: {equipments.Count}");
            builder.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return builder.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);
    }
}
