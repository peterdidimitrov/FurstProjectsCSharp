namespace CarManufacturer
{
    public class Tire
    {
        //fields
        private int year;
        private double pressure;

        //constructors
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        //properties
        public int Year { get { return year; } set { year = value; } }
        public double Pressure { get { return pressure; } set { pressure = value; } }
    }
}
