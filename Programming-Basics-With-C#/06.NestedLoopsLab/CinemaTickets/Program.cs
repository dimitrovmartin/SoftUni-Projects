using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            double kidsCount = 0;
            double studentsCount = 0;
            double standardCount = 0;

            while (movieName != "Finish")
            {
                double occupiedSeats = 0;

                int freeSeats = int.Parse(Console.ReadLine());

                while (occupiedSeats != freeSeats)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "student")
                    {
                        studentsCount++;
                        occupiedSeats++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardCount++;
                        occupiedSeats++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidsCount++;
                        occupiedSeats++;
                    }
                    else
                    {
                        break;
                    }

                }

                Console.WriteLine($"{movieName} - {occupiedSeats / freeSeats * 100:f2}% full.");

                movieName = Console.ReadLine();
            }

            double totalTickets = studentsCount + standardCount + kidsCount;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentsCount / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standardCount / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kidsCount / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
