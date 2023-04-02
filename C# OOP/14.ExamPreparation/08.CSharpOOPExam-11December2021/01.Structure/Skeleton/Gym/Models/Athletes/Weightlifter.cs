using Gym.Utilities.Messages;
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
            this.Stamina = IncreasingWeightlifterAmount + InitialWeightlifterStamina;
            //int newStamina = InitialWeightlifterStamina;
            Stamina += IncreasingWeightlifterAmount;
            if (Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
            //IncreaseStamina(IncreasingWeightlifterAmount);
        }
    }
}
