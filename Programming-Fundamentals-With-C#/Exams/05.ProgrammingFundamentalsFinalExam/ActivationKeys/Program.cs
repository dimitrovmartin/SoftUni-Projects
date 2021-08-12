using System;
using System.Text;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Generate")
            {
                string[] commandData = line
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "Contains")
                {
                    string substring = commandData[1];

                    if (rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                    line = Console.ReadLine();
                    continue;
                }
                else if (command == "Flip")
                {
                    string filter = commandData[1];

                    int start = int.Parse(commandData[2]);
                    int end = int.Parse(commandData[3]);

                    StringBuilder sb = new StringBuilder();

                    if (filter == "Upper")
                    {
                        for (int i = 0; i < rawActivationKey.Length; i++)
                        {
                            if (i >= start && i < end)
                            {
                                sb.Append(char.ToUpper(rawActivationKey[i]));
                            }
                            else
                            {
                                sb.Append(rawActivationKey[i]);
                            }
                        }
                    }
                    else if (filter == "Lower")
                    {
                        for (int i = 0; i < rawActivationKey.Length; i++)
                        {
                            if (i >= start && i < end)
                            {
                                sb.Append(char.ToLower(rawActivationKey[i]));
                            }
                            else
                            {
                                sb.Append(rawActivationKey[i]);
                            }
                        }
                    }

                    rawActivationKey = sb.ToString();
                }
                else if (command == "Slice")
                {
                    int start = int.Parse(commandData[1]);
                    int end = int.Parse(commandData[2]);

                    rawActivationKey = rawActivationKey.Remove(start, end - start);
                }

                Console.WriteLine(rawActivationKey);

                line = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
