using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const double baseCaloriesPerGram = 2;
        private const double meat = 1.2;
        private const double veddies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;
        

        private double weigh;
        private string toppingType;
        public string ToppingType
        {
            get { return toppingType; }
            private set { toppingType = value; }
        }
        public double Weigh
        {
            get { return weigh; }
            private set
            {
                if (value < 1 && value > 200)
                {
                    throw new AggregateException("[Topping type name] weight should be in the range [1..50].");
                }
                weigh = value;
            }
        }
        public double GetCalories()
        {
            double flourTypeCalories = 0;
            double bakingTechniqueCalories = 0;

            if (flourType == "white")
            {
                flourTypeCalories = whiteDoughCalories;
            }
            else if (flourType == "wholegrain")
            {
                flourTypeCalories = wholegrainDoughCalories;
            }
            if (bakingTechnique is "crispy")
            {
                bakingTechniqueCalories = crispyDoughCalories;
            }
            else if (bakingTechnique is "chewy")
            {
                bakingTechniqueCalories = chewyDoughCalories;
            }
            else if (bakingTechnique is "homemade")
            {
                bakingTechniqueCalories = homemadeDoughCalories;
            }
            return (weigh * doughCaloriesPerGram) * flourTypeCalories * bakingTechniqueCalories;
        }
    }
}
