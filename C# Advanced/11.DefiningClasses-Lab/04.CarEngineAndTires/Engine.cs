namespace CarManufacturer
{
    public class Engine
    {
        //fields
        private int horsePower;
        private double cubicCapacity;

        //constructor
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        //propurties
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public double CubicCapacity { get { return cubicCapacity; } set { cubicCapacity = value; } }
    }
}
