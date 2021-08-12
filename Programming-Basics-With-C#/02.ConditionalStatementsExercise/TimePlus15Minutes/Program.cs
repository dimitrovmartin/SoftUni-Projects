using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutesToSeconds = hours * 60;
            int totalSeconds = minutesToSeconds + minutes + 15;

            hours = totalSeconds / 60;
            minutes = totalSeconds % 60;

            if (hours == 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
