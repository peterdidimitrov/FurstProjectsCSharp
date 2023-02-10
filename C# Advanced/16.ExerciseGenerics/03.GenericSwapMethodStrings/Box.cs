using System.Text;

namespace GenericSwapMethodStrings
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
        public void Swap(List<int> input, List<Box<T>> boxList)
        {
            int firstIndex = input[0];
            int secondIndex = input[1];

            var temp = boxList[0];
            boxList[0] = boxList[1];
            boxList[1] = temp;
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