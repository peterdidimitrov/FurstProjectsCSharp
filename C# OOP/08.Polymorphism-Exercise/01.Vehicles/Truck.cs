namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double consumptionIncreased = 1.6; //consumption per km

        //truck has a tiny hole in its tank and when it’s refueled it keeps only 95% of the given fuel
        private const double percentKeepedFuel = 95;

        public Truck(double fuelQuantity, double fuelConsumption)
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
            FuelQuantity += refueledFuel * (percentKeepedFuel / 100);
        }
    }
}