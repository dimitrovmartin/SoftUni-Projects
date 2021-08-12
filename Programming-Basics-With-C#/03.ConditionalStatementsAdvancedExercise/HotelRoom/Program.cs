using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double nights = double.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;
                    if (nights > 7 && nights <= 14)
                    {
                        studioPrice -= (50 * 0.05);

                    }
                    else if (nights > 14)
                    {
                        studioPrice -= studioPrice * 0.3;
                        apartmentPrice -= apartmentPrice * 0.1;
                    }

                    break;
                case "June":
                case "September":
                    studioPrice = 75.2;
                    apartmentPrice = 68.7;

                    if (nights > 14)
                    {
                        studioPrice -= studioPrice * 0.2;
                        apartmentPrice -= apartmentPrice * 0.1;
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;

                    if (nights > 14)
                    {
                        apartmentPrice -= apartmentPrice * 0.1;
                    }
                    break;
                default:

                    break;
            }
            double totalStudioPrice = studioPrice * nights;
            double totalApartmentPrice = apartmentPrice * nights;

            Console.WriteLine($"Apartment: {totalApartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:f2} lv.");
        }
    }
}
