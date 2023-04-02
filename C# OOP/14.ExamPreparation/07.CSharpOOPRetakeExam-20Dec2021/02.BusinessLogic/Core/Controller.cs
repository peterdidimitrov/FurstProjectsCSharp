using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vesselRepository;
        private List<ICaptain> captains;
        public Controller()
        {
            vesselRepository = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            var vessel = vesselRepository.FindByName(selectedVesselName);
            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vesselRepository.FindByName(attackingVesselName);
            var defendingVessel = vesselRepository.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (attackingVessel.ArmorThickness == 0 || defendingVessel.ArmorThickness == 0)
            {
                if (attackingVessel.ArmorThickness == 0)
                {
                    return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
                }
                else if (defendingVessel.ArmorThickness == 0)
                {
                    return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
                }
            }

            attackingVessel.Attack(defendingVessel);

            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var assignedCaptain = captains.FirstOrDefault(c => c.FullName == captainFullName);
            return assignedCaptain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            if (vesselRepository.Models.Any(v => v.Name == name))
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            vesselRepository.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);
            if (vessel.GetType().Name == "Battleship" && vesselRepository.Models.Any(v => v.Name == vesselName))
            {
                var battleship = vessel as Battleship;
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel.GetType().Name == "Submarine" && vesselRepository.Models.Any(v => v.Name == vesselName))
            {
                var submarine = vessel as Submarine;
                submarine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}
