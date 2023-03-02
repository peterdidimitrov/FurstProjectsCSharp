namespace Cars.Interfaces
{
    interface ICar
    {
        public string Model { get; }
        public string Color { get; }

        public abstract void Start();
        public abstract void Stop();
    }
}