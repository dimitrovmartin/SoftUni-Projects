using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int bookCount = 0;

            bool isFound = false;

            while (currentBook != "No More Books")
            {
                if (currentBook == book)
                {
                    Console.WriteLine($"You checked {bookCount} books and found it.");

                    isFound = true;
                    break;
                }

                bookCount++;

                currentBook = Console.ReadLine();
            }

            if (!isFound)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {bookCount} books.");
            }
        }
    }
}
