using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private new const double Weight = 10000;
        private new const decimal Price = 80;
        public Kettlebell() : base(Weight, Price)
        {
        }
    }
}
