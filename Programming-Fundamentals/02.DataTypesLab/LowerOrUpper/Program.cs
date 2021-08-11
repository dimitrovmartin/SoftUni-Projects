using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            if (Char.IsLower(character))
            {
                Console.WriteLine($"lower-case");
            }
            else if (char.IsUpper(character))
            {
                Console.WriteLine($"upper-case");
            }
        }
    }
}
