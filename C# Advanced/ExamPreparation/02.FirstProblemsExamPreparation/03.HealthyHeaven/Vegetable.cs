using System.Text;

namespace HealthyHeaven
{
    public class Vegetable
    {
        public Vegetable(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public string Name { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            //- {name} have {calories} calories
            StringBuilder result = new StringBuilder();

            result.AppendLine($"- {Name} have {Calories} calories");

            return result.ToString().Trim();
        }
    }
}
