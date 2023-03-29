using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1CarModel, this.model);
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1HorsePower, horsepower.ToString());
                }
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1EngineDisplacement, engineDisplacement.ToString());
                }
                engineDisplacement = value;
            }
        }

        //engine displacement / horsepower * laps
        public double RaceScoreCalculator(int laps) => EngineDisplacement / Horsepower * laps;
    }
}
