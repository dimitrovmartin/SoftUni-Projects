using System;
using System.Text;

namespace CharToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                char character = char.Parse(Console.ReadLine());

                str += character.ToString();
            }

            Console.WriteLine(str);
        }
    }
}
