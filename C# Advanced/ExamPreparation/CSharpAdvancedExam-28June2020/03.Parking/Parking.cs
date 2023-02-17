using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var targetCar = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (targetCar == null)
            {
                return false;
            }
            this.data.Remove(targetCar);
            return true;

        }

        public Car GetLatestCar()
        {
            if (Count <= 0)
            {
                return null;
            }
            var targetCar = this.data.OrderByDescending(x => x.Year).First();
            if (targetCar == null)
            {
                return null;
            }
            return targetCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var targetCar = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (targetCar == null)
            {
                return null;
            }
            return targetCar;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
