using System.Text;

namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            FishType = fishType;
            Length = length;
            Weight = weight;
        }

        public string FishType { get; private set; }
        public double Length { get; private set; }
        public double Weight { get; private set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
