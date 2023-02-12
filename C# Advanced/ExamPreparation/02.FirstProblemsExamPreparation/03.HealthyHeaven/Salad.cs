using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            Name = name;
            products = new List<Vegetable>();
        }

        public string Name { get; private set; }
        //public int GetTotalCalories()
        //{
        //    int sumOfCalories = 0;
        //    foreach (var product in products)
        //    {
        //        sumOfCalories += product.Calories;
        //    }
        //    return sumOfCalories;

        //}
        public int GetTotalCalories() => this.products.Sum(x => x.Calories);
        public int GetProductCount()
        {
            return products.Count;
        }
        public void Add(Vegetable product)
        {
            products.Add(product);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
            foreach (var product in products)
            {
                result.AppendLine($"{product.ToString()}");
            }

            return result.ToString().Trim();
        }
    }
}
