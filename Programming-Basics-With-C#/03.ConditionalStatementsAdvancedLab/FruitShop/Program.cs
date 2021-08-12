using System;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        price = 2.5 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "apple")
                    {
                        price = 1.2 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "orange")
                    {
                        price = 0.85 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = 1.45 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        price = 2.7 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        price = 5.5 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "grapes")
                    {
                        price = 3.85 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        price = 2.7 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "apple")
                    {
                        price = 1.25 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "orange")
                    {
                        price = 0.9 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = 1.6 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        price = 3 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        price = 5.6 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (fruit == "grapes")
                    {
                        price = 4.2 * quantity;
                        Console.WriteLine($"{price:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
