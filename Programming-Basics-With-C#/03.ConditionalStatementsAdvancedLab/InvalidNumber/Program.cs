using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if ((num != 0) && ((num <= 99) || (num >= 201)))
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
