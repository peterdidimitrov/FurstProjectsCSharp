using SingletonDemo.Models;

namespace SingletonDemo
{
    public class Program
    {
        public static void Main()
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Washington"));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("London"));
            var db3 = SingletonDataContainer.Instance;
            Console.WriteLine(db3.GetPopulation("London"));
            var db4 = SingletonDataContainer.Instance;
        }
    }
}