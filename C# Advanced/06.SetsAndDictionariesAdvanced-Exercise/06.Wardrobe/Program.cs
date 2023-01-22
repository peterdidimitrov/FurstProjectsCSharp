using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] strings = Console.ReadLine().Split(" -> ");
                string color = strings[0];

                var clothes = strings[1].Split(',').ToList();

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                    for (int j = 0; j < clothes.Count; j++)
                    {
                        if (!clothesByColor[color].ContainsKey(clothes[j]))
                        {
                            clothesByColor[color].Add(clothes[j], 1);
                        }
                        else
                        {
                            clothesByColor[color][clothes[j]]++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < clothes.Count; j++)
                    {
                        if (!clothesByColor[color].ContainsKey(clothes[j]))
                        {
                            clothesByColor[color].Add(clothes[j], 1);
                        }
                        else
                        {
                            clothesByColor[color][clothes[j]]++;
                        }
                    }
                }
            }
            string[] searched = Console.ReadLine().Split();
            string desiredColor = searched[0];
            string desiredCloth = searched[1];

            foreach (var color in clothesByColor)
            {
                string currColor = color.Key;
                Console.WriteLine($"{currColor} clothes:");

                foreach (var cloth in color.Value)
                {
                    string currCloth = cloth.Key;

                    if (currColor == desiredColor && currCloth == desiredCloth)
                    {
                        Console.WriteLine($"* {currCloth} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currCloth} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
