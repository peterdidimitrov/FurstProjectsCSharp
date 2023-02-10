using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box<T>
    {
        private List<T> items; //field

        //constructor
        public Box()
        {
            items = new List<T>();
        }
        public void Add(T item)
        {
            items.Add(item);
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
        override public string ToString()
        {
            StringBuilder sb = new();

            foreach (var item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}