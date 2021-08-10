using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();

            string pattern = @"\+359([\s-])2\1\d{3}\1\d{4}\b";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(numbers);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
