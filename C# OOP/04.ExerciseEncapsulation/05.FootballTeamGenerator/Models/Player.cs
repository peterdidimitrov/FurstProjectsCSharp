using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public Stats Stats
        {
            get { return stats; }
            private set { stats = value; }
        }
        private int GetSkilLevel() => (stats.Endurance + stats.Dribble + stats.Passing + stats.Sprint + stats.Shooting) / 5;

    }
}
