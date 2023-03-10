using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Dog : Feline
    {
        public Dog(string name, int weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public override string ProducingSound()
        {
            throw new NotImplementedException();
        }
    }
}
