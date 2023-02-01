using System.Text;

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

        //methods
        public string ShowEngine()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"-> Horse power: {this.HorsePower}");
            stringBuilder.AppendLine($"-> Cubic capacity: {this.CubicCapacity}");
            return stringBuilder.ToString();
        }
    }
}
