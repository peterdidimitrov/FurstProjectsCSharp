using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            IRacer winner;

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                winner = racerTwo;
                return string.Format(OutputMessages.OneRacerIsNotAvailable, winner, racerOne);
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                winner = racerOne;
                return string.Format(OutputMessages.OneRacerIsNotAvailable, winner, racerTwo);
            }

            racerOne.Race();
            racerTwo.Race();


            if ((racerOne.Car.HorsePower * racerOne.DrivingExperience * BrehaviorMultiplier(racerOne)) > racerTwo.Car.HorsePower * racerTwo.DrivingExperience * BrehaviorMultiplier(racerTwo))
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }

            return string.Format(OutputMessages.RacerWinsRace, racerOne, racerTwo, winner.Username);
        }
        private double BrehaviorMultiplier(IRacer racer)
        {
            double racerBrehaviorMultiplier;
            if (racer.RacingBehavior == "strict")
            {
                racerBrehaviorMultiplier = 1.2;
            }
            else
            {
                racerBrehaviorMultiplier = 1.1;
            }
            return racerBrehaviorMultiplier;
        }
    }
}
