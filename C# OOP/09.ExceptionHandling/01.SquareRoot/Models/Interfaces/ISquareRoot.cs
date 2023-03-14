using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoots.Models.Interfaces
{
    public interface ISquareRoot
    {
        public int Number { get; }

        public double GetSquareRoot();
    }
}
