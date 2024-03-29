﻿using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialSubmarineArmorThickness = 200;
        private const double SubmergeModeWeaponCaliberBonus = 40;
        private const double SubmergeModeSpeedPenalty = 4;
        private bool submarineMode;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialSubmarineArmorThickness)
        {
            submarineMode = false;
        }

        public bool SubmergeMode
        {
            get
            {
                return submarineMode;
            }
            private set
            {
                submarineMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < InitialSubmarineArmorThickness)
            {
                ArmorThickness = InitialSubmarineArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                MainWeaponCaliber -= SubmergeModeWeaponCaliberBonus;
                Speed += SubmergeModeSpeedPenalty;
            }
            else
            {
                MainWeaponCaliber += SubmergeModeWeaponCaliberBonus;
                Speed -= SubmergeModeSpeedPenalty;
            }

            SubmergeMode = !SubmergeMode;
        }
        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine} *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}";
        }
    }
}
