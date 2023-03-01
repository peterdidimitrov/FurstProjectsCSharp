using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const double doughCaloriesPerGram = 2;
        private const double whiteDoughCalories = 1.5;
        private const double wholegrainDoughCalories = 1.0;
        private const double crispyDoughCalories = 0.9;
        private const double chewyDoughCalories = 1.1;
        private const double homemadeDoughCalories = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weigh;

        public Dough(string flourType, string bakingTechnique, double weigh)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weigh = weigh;
        }

        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new AggregateException("Invalid type of dough.");
                }
                flourType = value; 
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set 
            {
                if (value is not "crispy" && value is not "chewy" && value is not "homemade")
                {
                    throw new AggregateException("Invalid type of dough.");
                }
                bakingTechnique = value; 
            }
        }
        public double Weigh
            { 
            get { return weigh; } 
            private set 
            {
                if (value < 1 && value > 200)
                {
                    throw new AggregateException("Dough weight should be in the range [1..200].");
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
