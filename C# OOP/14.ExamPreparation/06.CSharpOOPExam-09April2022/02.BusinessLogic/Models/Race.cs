using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;

            TookPlace = tookPlace;
        }
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName, raceName);
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers, this.numberOfLaps.ToString());
                }

                numberOfLaps = value;
            }
        }
        private List<IPilot> pilots = new List<IPilot>();

        public bool TookPlace { get => tookPlace; set { tookPlace = value; } }

        public ICollection<IPilot> Pilots => pilots.AsReadOnly();

        public void AddPilot(IPilot pilot) => pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            if (TookPlace == false)
            {
                sb.AppendLine($"Took place: No");
            }
            else
            {
                sb.AppendLine($"Took place: Yes");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
