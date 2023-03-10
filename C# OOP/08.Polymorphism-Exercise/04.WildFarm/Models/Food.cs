using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        public int Quantity { get; private set; } 
    }
}
