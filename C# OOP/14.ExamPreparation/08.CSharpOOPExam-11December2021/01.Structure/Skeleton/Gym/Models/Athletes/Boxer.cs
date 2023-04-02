using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialBoxerStamina = 60;
        private const int IncreasingBoxerAmount = 15;
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialBoxerStamina)
        {
        }

        public override void Exercise()
        {
            IncreaseStamina(IncreasingBoxerAmount);
        }
    }
}
