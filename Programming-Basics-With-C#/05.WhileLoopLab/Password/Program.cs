using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string currentPassword = Console.ReadLine();

            string password = Console.ReadLine();

            while (password != currentPassword)
            {
                password = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
