using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialBattleshipArmorThickness = 300;
        private const double SonarModeWeaponCaliberBonus = 40;
        private const double SonarModeSpeedPenalty = 5;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialBattleshipArmorThickness)
        {
            sonarMode = false;
        }

        public bool SonarMode
        {
            get
            {
                return sonarMode;
            }
            private set
            {
                sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < InitialBattleshipArmorThickness)
            {
                ArmorThickness = InitialBattleshipArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                MainWeaponCaliber -= SonarModeWeaponCaliberBonus;
                Speed += SonarModeSpeedPenalty;
            }
            else
            {
                MainWeaponCaliber += SonarModeWeaponCaliberBonus;
                Speed -= SonarModeSpeedPenalty;
            }

            SonarMode = !SonarMode;
        }
        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine} *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
        }
    }
}
