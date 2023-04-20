using SingletonDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo.Models
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();
        private static SingletonDataContainer instance = new SingletonDataContainer();

        public static SingletonDataContainer Instance => instance;
        public SingletonDataContainer()
        {
            string path = "../../../capitals.txt";
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines(path);

            for (int i = 0; i < elements.Length; i += 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
