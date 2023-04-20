using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Models
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }

        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }
        public CarInfoBuilder WithNumberOfDoors(int number)
        {
            Car.NumberOfDoors = number;
            return this;
        }
    }
}
