using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ")
                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] comArg = command.Split(" - ");
                string currentCommand = comArg[0];

                if (currentCommand == "Collect")
                {
                    string currentItem = comArg[1];
                    if (items.Contains(currentItem))
                    {
                        continue;
                    }
                    else
                    {
                        items.Add(currentItem);
                    }
                }
                else if (currentCommand == "Drop")
                {
                    string currentItem = comArg[1];
                    if (items.Contains(currentItem))
                    {
                        items.Remove(currentItem);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCommand == "Combine Items")
                {
                    CombinatingItems(items, comArg);
                }
                else if (currentCommand == "Renew")
                {
                    RenewingItem(items, comArg);
                }
            }
            Console.WriteLine(string.Join(", ", items));
        }

        private static void CombinatingItems(List<string> items, string[] comArg)
        {
            string currentItem = comArg[1];
            string[] splitItems = currentItem.Split(":");
            string oldItem = splitItems[0];
            string newItem = splitItems[1];

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == oldItem)
                {
                    items.Insert(i + 1, newItem);
                }
            }
        }

        private static void RenewingItem(List<string> items, string[] comArg)
        {
            string currentItem = comArg[1];
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == currentItem)
                {
                    items.Add(currentItem);
                    items.RemoveAt(i);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
