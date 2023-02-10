using System.Text;

namespace GenericBoxOfInteger
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
