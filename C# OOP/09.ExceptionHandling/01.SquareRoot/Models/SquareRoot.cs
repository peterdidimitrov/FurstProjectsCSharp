using SquareRoots.Models.Interfaces;

namespace SquareRoots.Models
{
    public class SquareRoot : ISquareRoot
    {
        private int number;

        public SquareRoot(int number)
        {
            Number = number;
        }

        public int Number 
        {
            get { return number; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                number = value; 
            }
        }

        public double GetSquareRoot() => (int)(Math.Sqrt((double)number));
    }
}
