using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int startingHealth = n;
            int count = 0;

            while (n >= m)
            {
                n -= m;
                count++;

                if (startingHealth / 2 == n && y > 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(count);
        }
    }
}
