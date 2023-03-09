namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption; //fuel consumption in liters per km

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value; }
        }
        public abstract string Drive(double distance);
        public abstract void Refuel(double refueledFuel);
        public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}