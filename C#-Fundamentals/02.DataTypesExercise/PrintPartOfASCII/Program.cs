using System;

namespace PrintPartOfASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for (int i = n; i <= m; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
