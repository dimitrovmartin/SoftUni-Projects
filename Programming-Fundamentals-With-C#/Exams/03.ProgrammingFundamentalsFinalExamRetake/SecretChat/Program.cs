using System;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Reveal")
            {
                string[] commandData = line
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(commandData[1]);

                    secretMessage = secretMessage.Insert(index, " ");
                }
                else if (command == "Reverse")
                {
                    string substring = commandData[1];

                    if (secretMessage.Contains(substring))
                    {
                        int substringIndex = secretMessage.IndexOf(substring);

                        secretMessage = secretMessage.Remove(substringIndex, substring.Length);

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            secretMessage += substring[i];
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");

                        line = Console.ReadLine();
                        continue;
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = commandData[1];
                    string replacement = commandData[2];

                    secretMessage = secretMessage.Replace(substring, replacement);
                }

                Console.WriteLine(secretMessage);

                line = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {secretMessage}");
        }
    }
}
