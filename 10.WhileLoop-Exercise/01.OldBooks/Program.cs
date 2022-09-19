using System;

namespace _01.OldBooks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            string currentBook = Console.ReadLine();
            int countBooks = 0;
            bool isTheFavoriteBook = true;
            while (currentBook != favoriteBook)
            {

                if (currentBook == "No More Books")
                {
                    isTheFavoriteBook = false;
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {countBooks} books.");
                    break;
                }
                countBooks++;
                currentBook = Console.ReadLine();
            }
            if (isTheFavoriteBook)
            {
                Console.WriteLine($"You checked {countBooks} books and found it.");
            }
        }
    }
}