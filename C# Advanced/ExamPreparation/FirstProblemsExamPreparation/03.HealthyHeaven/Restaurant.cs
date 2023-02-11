using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> salads;

        public Restaurant(string name)
        {
            Name = name;
            salads = new List<Salad>();
        }

        public string Name { get; private set; }

        public void Add(Salad salad)
        {
            salads.Add(salad);
        }
        public bool Buy(string name)
        {
            if (salads.Any(x => x.Name == name))
            {
                salads.RemoveAll(x => x.Name == name);
                return true;
            }
            return false;
        }
        public Salad GetHealthiestSalad()
        {
            return salads.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();

        }
        public string GenerateMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine($"{Name} have {salads.Count()} salads:");
            foreach (var salad in salads)
            {
                menu.AppendLine($"{salad}");
            }
            
            return menu.ToString().TrimEnd();
        }
    }
}
