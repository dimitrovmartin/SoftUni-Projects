using System;
using System.Text;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Finish")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "Replace")
                {
                    string substring = commandData[1];
                    string replace = commandData[2];

                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, replace);
                    }
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(commandData[1]);
                    int endIndex = int.Parse(commandData[2]);

                    if (IsValidIndex(text, startIndex) && IsValidIndex(text,endIndex))
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < text.Length; i++)
                        {
                            if (i >= startIndex && i <= endIndex)
                            {
                                continue;
                            }
                            else
                            {
                                sb.Append(text[i]);
                            }
                        }

                        text = sb.ToString();
                    }
                    else
                    {
                        Console.WriteLine($"Invalid indices!");

                        line = Console.ReadLine();
                        continue;
                    }
                }
                else if (command == "Make")
                {
                    string filter = commandData[1];

                    if (filter == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else if (filter == "Lower")
                    {
                        text = text.ToLower();
                    }
                }
                else if (command == "Check")
                {
                    string substring = commandData[1];

                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }

                    line = Console.ReadLine();

                    continue;
                }
                else if (command == "Sum")
                {
                    int startIndex = int.Parse(commandData[1]);
                    int endIndex = int.Parse(commandData[2]);

                    if (IsValidIndex(text,startIndex) && IsValidIndex(text,endIndex))
                    {
                        string substring = text.Substring(startIndex, endIndex - startIndex + 1);

                        int sum = 0;

                        foreach (var character in substring)
                        {
                            sum += character;
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid indices!");
                    }

                    line = Console.ReadLine();

                    continue;
                }

                Console.WriteLine(text);

                line = Console.ReadLine();
            }
        }

        private static bool IsValidIndex(string text, int startIndex)
        {
            return startIndex >= 0 && startIndex < text.Length;
        }
    }
}
