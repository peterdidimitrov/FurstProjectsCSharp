﻿using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name  
        {
            get { return name; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidEggName));
                }
                name = value; }
        }

        public int EnergyRequired
        {
            get { return energyRequired; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energyRequired = value; }
        }


        public void GetColored()
        {
            EnergyRequired -= 10;
            if (EnergyRequired < 0)
            {
                EnergyRequired = 0;
            }
        }

        public bool IsDone() => energyRequired == 0;
    }
}
