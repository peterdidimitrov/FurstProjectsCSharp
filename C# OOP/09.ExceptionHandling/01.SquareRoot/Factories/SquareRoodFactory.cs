using SquareRoots.Factories.Interfaces;
using SquareRoots.Models;
using SquareRoots.Models.Interfaces;

namespace SquareRoots.Factories
{
    public class SquareRoodFactory : ISquqreRootFactory
    {
        public ISquareRoot Create(int number) => new SquareRoot(number);
    }
}
