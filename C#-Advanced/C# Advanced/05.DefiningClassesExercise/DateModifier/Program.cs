using System;
using System.Linq;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            Console.WriteLine(DateModifier.GetDifferenceBetweenTwoDates(first, second));
        }
    }
}
