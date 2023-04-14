﻿using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        
        private int convertionCapacityIndex;
        private readonly List<int> interfaceStandards;
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;

            BatteryLevel = batteryCapacity;

            interfaceStandards = new List<int>();

        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex
        {
            get => convertionCapacityIndex;
            private set
            {
                convertionCapacityIndex = value;
            }
        }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            BatteryLevel += ConvertionCapacityIndex * minutes;

            if (BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);

            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }
        public override string ToString()
        {
            Type type = GetType();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{type.Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            List<int> supplimentsList = new List<int>();
            foreach (var suppliment in interfaceStandards)
            {
                supplimentsList.Add(suppliment);
            }

            if (supplimentsList.Count == 0)
            {
                sb.AppendLine("--Supplements installed: none");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: {string.Join(" ", supplimentsList)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
