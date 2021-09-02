using System;
using System.Text;

namespace TheImitationGame
{
    class EncryptedMessage
    {
        public EncryptedMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

        public void Move(int n)
        {
            if (n <= Message.Length)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder lettersToMove = new StringBuilder();

                for (int i = 0; i < Message.Length; i++)
                {
                    if (i >= n)
                    {
                        sb.Append(Message[i]);
                    }
                    else
                    {
                        lettersToMove.Append(Message[i]);
                    }
                }

                sb.Append(lettersToMove);

                Message = sb.ToString();
            }
        }

        public void Insert(int index, string value)
        {
            if (index >= 0 && index <= Message.Length)
            {
                Message = Message.Insert(index, value);
            }
        }

        public void ChangeAll(string substring, string replacement)
        {
            if (Message.Contains(substring))
            {
                Message = Message.Replace(substring, replacement);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            EncryptedMessage encryptedMessage = new EncryptedMessage(message);

            string line = Console.ReadLine();

            while (line != "Decode")
            {
                string[] commandData = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "Move")
                {
                    int n = int.Parse(commandData[1]);

                    encryptedMessage.Move(n);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(commandData[1]);
                    string value = commandData[2];

                    encryptedMessage.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = commandData[1];
                    string replacement = commandData[2];

                    encryptedMessage.ChangeAll(substring, replacement);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage.Message}");
        }
    }
}
