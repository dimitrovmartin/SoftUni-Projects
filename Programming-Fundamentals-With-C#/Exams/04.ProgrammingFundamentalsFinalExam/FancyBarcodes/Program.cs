using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string barcodePattern = @"^@#+([A-Z][A-Za-z\d]{4,}[A-Z])@#+$";
            string digitsPattern = @"\d";

            Regex barcodeRegex = new Regex(barcodePattern);
            Regex digitsRegex = new Regex(digitsPattern);

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                Match match = barcodeRegex.Match(barcode);

                if (match.Success)
                {
                    MatchCollection matches = digitsRegex.Matches(barcode);

                    if (matches.Any())
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (Match digit in matches)
                        {
                            sb.Append(digit);
                        }

                        Console.WriteLine($"Product group: {sb}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}
