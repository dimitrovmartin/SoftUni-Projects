using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            bool isTrue = false;

            for (int i = 0; i < 4; i++)
            {
                string currentPassword = Console.ReadLine();

                if (currentPassword == password)
                {
                    isTrue = true;
                    break;
                }
                else
                {
                    if (i < 3)
                    {
                    Console.WriteLine($"Incorrect password. Try again.");
                    }
                }
            }

            if (isTrue)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            else
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
