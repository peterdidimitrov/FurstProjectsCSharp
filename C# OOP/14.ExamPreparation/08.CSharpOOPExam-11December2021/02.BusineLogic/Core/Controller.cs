using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private List<IGym> gyms;
        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            var desiredGym = gyms.FirstOrDefault(g => g.Name == gymName);
            if ((athlete.GetType().Name == "Boxer" && desiredGym.GetType().Name == "WeightliftingGym") || (athlete.GetType().Name == "Weightlifter" && desiredGym.GetType().Name == "BoxingGym"))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            desiredGym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipments.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var desiredGym = gyms.FirstOrDefault(g => g.Name == gymName);
            var weight = desiredGym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var desiredEquipment = equipments.FindByType(equipmentType);
            var desiredGym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (desiredEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            desiredGym.AddEquipment(desiredEquipment);
            equipments.Remove(desiredEquipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var builder = new StringBuilder();

            foreach (var gym in gyms)
            {
                builder.AppendLine(gym.GymInfo());
            }

            return builder.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var desiredGym = gyms.FirstOrDefault(g => g.Name == gymName);
            desiredGym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, desiredGym.Athletes.Count);
        }
    }
}
