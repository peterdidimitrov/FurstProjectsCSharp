using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }

        IReadOnlyCollection<Shoe> Shoes => Shoes;
        public int Count => shoes.Count;
        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity == shoes.Count)
            {
                return $"No more space in the storage room.";
            }
            shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
        public int RemoveShoes(string material)
        {
            int removedShoes = 0;
            foreach (var shoe in Shoes)
            {
                if (material.ToLower() == shoe.Material)
                {
                    shoes.Remove(shoe);
                    removedShoes++;
                }
            }
            return removedShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> listToReturn = new();
            foreach (var shoe in shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    listToReturn.Add(shoe);
                }
            }
            return listToReturn;
        }

        public Shoe GetShoeBySize(double size) => shoes.FirstOrDefault(s => s.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> listToReturn = new();
            foreach (var shoe in shoes)
            {
                if (size == shoe.Size && type == shoe.Type)
                {
                    listToReturn.Add(shoe);
                }
            }
            StringBuilder sb = new();
            if (listToReturn.Any())
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (Shoe shoe1 in listToReturn)
                {
                    sb.AppendLine(shoe1.ToString());
                }
            }
            else
            {
                sb.AppendLine("No matches found!");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
