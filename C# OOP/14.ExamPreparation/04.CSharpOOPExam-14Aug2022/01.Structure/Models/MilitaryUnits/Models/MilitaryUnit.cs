﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Models
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost 
        {
            get => cost;
            private set
            { 
                cost = value;
            }
        }

        public int EnduranceLevel
        {
            get => enduranceLevel;
            private set
            {
                if (true)
                {

                }
                enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            EnduranceLevel += 1;
            if (EnduranceLevel > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
