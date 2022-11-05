using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AdvertisementMessage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numOfMessages = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            List<string> phrases = new List<string>()
               {"Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."};

            List<string> events = new List<string>()
               {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"};

            List<string> authors = new List<string>()
                {"Diana",
                 "Petya",
                 "Stella",
                 "Elena",
                 "Katya",
                 "Iva",
                 "Annie",
                 "Eva"};
            List<string> cities = new List<string>()
            {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};



            for (int i = 0; i < numOfMessages; i++)
            {
                int phraseIndex = rnd.Next(phrases.Count);
                int eventIndex = rnd.Next(events.Count);
                int authorIndex = rnd.Next(authors.Count);
                int cityIndex = rnd.Next(cities.Count);

                Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} – {cities[cityIndex]}.");
            }
        }
    }
}