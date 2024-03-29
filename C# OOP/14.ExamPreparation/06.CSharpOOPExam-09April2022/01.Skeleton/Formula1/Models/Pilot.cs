﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPilot, this.fullName);
                }

                fullName = value;
            }
        }

        public bool CanRace 
        { 
            get => false; 
            private set { value = false; }
        }

        public IFormulaOneCar Car
        {
            get { return this.Car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                Car = value;
            }
        }

        public int NumberOfWins
        {
            get => default; 
            private set { value = default; }
        }


        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
