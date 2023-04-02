using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;

            targets = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
        }

        public double ArmorThickness 
        { 
            get 
            { return armorThickness; } 
            set 
            { armorThickness = value; } 
        }

        public double MainWeaponCaliber 
        { 
            get 
            { return mainWeaponCaliber; } 
            protected set 
            { mainWeaponCaliber = value; } 
        }

        public double Speed 
        {
            get 
            { return speed; } 
            protected set 
            { speed = value; }
        }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }
            target.ArmorThickness -= mainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        //public void DecreaseMainWeaponCaliberAndInceaseSpeed(double bonus, double penalty)
        //{
        //    MainWeaponCaliber -= bonus;
        //    Speed += penalty;
        //}
        //public void InceaseMainWeaponCaliberDecreaseSpeed(double bonus, double penalty)
        //{
        //    MainWeaponCaliber += bonus;
        //    Speed -= penalty;
        //}

        public override string ToString()
        {
            Type type = GetType();
 
            string[] typeOfVessel = type.ToString().Split(".").TakeLast(1).ToArray();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {typeOfVessel[0]}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.Append(" *Targets: ");
            if (targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.Append(string.Join(", ", targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
