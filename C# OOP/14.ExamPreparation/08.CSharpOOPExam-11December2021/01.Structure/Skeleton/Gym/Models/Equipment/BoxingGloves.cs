using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private new const double Weight = 227;
        private new const decimal Price = 120;
        public BoxingGloves() 
            : base(Weight, Price)
        {
        }
    }
}
