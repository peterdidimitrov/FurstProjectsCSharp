using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitialWeightlifterStamina = 50;
        private const int IncreasingWeightlifterAmount = 10;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, InitialWeightlifterStamina)
        {
        }

        public override void Exercise()
        {
            IncreaseStamina(IncreasingWeightlifterAmount);
        }
    }
}
