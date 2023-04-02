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
        private const double InitialArmorThickness = 300;
        private const double SonarModeWeaponCaliberBonus = 40;
        private const double SonarModeSpeedPenalty = 5;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
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
            if (ArmorThickness < InitialArmorThickness)
            {
                ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                DecreaseMainWeaponCaliberAndInceaseSpeed(SonarModeWeaponCaliberBonus, SonarModeSpeedPenalty);
            }
            else
            {
                InceaseMainWeaponCaliberDecreaseSpeed(SonarModeWeaponCaliberBonus, SonarModeSpeedPenalty);
            }

            SonarMode = !SonarMode;
        }
        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine} *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
        }
    }
}
