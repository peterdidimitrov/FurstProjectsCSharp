using Cars.Interfaces;

public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            this.battery = battery;
        }

        public string Model
        {
            get => model;
            private set
            {
                model = value;
            }
        }

        public string Color
        {
            get => color;
            private set
            {
                color = value;
            }
        }

        public int Battery
        {
            get => battery;
            private set
            {
                battery = value;
            }
        }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }
        public override string ToString()
        {
            return $"{color} {nameof(Tesla)} {Model} with {Battery} Batteries";
        }
}