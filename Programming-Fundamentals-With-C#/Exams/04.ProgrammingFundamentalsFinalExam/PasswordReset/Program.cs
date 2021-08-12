using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawPassword = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Done")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 1; i < rawPassword.Length; i += 2)
                    {
                        sb.Append(rawPassword[i]);
                    }

                    rawPassword = sb.ToString();
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(commandData[1]);
                    int length = int.Parse(commandData[2]);

                    rawPassword = rawPassword.Remove(index, length);
                }
                else if (command == "Substitute")
                {
                    string substring = commandData[1];
                    string substitute = commandData[2];

                    if (rawPassword.Contains(substring))
                    {
                        rawPassword = rawPassword.Replace(substring, substitute);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");

                        line = Console.ReadLine();

                        continue;
                    }
                }

                Console.WriteLine(rawPassword);

                line = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {rawPassword}");
        }
    }
}
