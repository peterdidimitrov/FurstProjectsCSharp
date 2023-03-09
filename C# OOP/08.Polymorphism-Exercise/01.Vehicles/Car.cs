namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double consumptionIncreased = 0.9; //consumption per km
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double distance)
        {
            if (FuelQuantity >= distance * (FuelConsumption + consumptionIncreased))
            {
                FuelQuantity -= distance * (FuelConsumption + consumptionIncreased);

                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public override void Refuel(double refueledFuel)
        {
            FuelQuantity += refueledFuel;
        }
    }
}