using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Travel")
            {
                string[] commandData = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(commandData[1]);
                    string stop = commandData[2];

                    if (IsValidIndex(stops, index))
                    {
                        stops = stops.Insert(index, stop);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(commandData[1]);
                    int endIndex = int.Parse(commandData[2]);

                    if (IsValidIndex(stops, startIndex) && IsValidIndex(stops, endIndex))
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (command == "Switch")
                {
                    string oldStop = commandData[1];
                    string newStop = commandData[2];

                    if (stops.Contains(oldStop))
                    {
                        stops = stops.Replace(oldStop, newStop);
                    }
                }

                Console.WriteLine(stops);

                line = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        private static bool IsValidIndex(string stops, int index)
        {
            return index >= 0 && index < stops.Length;
        }
    }
}
