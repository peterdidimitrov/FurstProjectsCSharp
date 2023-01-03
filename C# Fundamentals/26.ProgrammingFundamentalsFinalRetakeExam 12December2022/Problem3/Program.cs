using System;
using System.Collections.Generic;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, List<string>>();
            var allItems = new List<string>();
            var inportant = new List<string>();

            string commands;

            while ((commands = Console.ReadLine()) != "Go Shopping")
            {
                string[] commArg = commands
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string currCommand = commArg[0];
                string store = commArg[1];

                if (currCommand == "Add")
                {
                    string[] items = commArg[2]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries);

                    if (!stores.ContainsKey(store))
                    {
                        stores.Add(store, new List<string>());

                        for (int i = 0; i < items.Length; i++)
                        {
                            if (!allItems.Contains(items[i]))
                            {
                                stores[store].Add(items[i]);
                                allItems.Add(items[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (!allItems.Contains(items[i]))
                            {
                                stores[store].Add(items[i]);
                                allItems.Add(items[i]);
                            }
                        }
                    }
                }
                else if (currCommand == "Important")
                {
                    string majorItem = commArg[2];
                    if (!stores.ContainsKey(store))
                    {
                        stores.Add(store, new List<string>());

                        if (!allItems.Contains(majorItem))
                        {
                            stores[store].Insert(0, majorItem);
                            allItems.Add(majorItem);
                            inportant.Add(store);
                        }
                    }
                    else
                    {
                        if (!allItems.Contains(majorItem))
                        {
                            stores[store].Insert(0, majorItem);
                            allItems.Add(majorItem);
                            inportant.Add(store);
                        }
                    }
                }
                else if (currCommand == "Remove")
                {
                    if (!inportant.Contains(store) && stores.ContainsKey(store))
                    {
                        stores.Remove(store);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (var store in stores)
            {
                string storeName = store.Key;
                List<string> items =store.Value;
                Console.WriteLine($"{storeName}:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
    }
}
