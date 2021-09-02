using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class User
    {
        public User(string name, int sentedMessages, int receivedMessages)
        {
            Name = name;
            SentedMessages = sentedMessages;
            ReceivedMessages = receivedMessages;
        }

        public string Name { get; set; }

        public int SentedMessages { get; set; }

        public int ReceivedMessages { get; set; }

        public int TotalMessages => SentedMessages + ReceivedMessages;

        public override string ToString()
        {
            return $"{Name} - {TotalMessages}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> usersByName = new Dictionary<string, User>();

            int messagesCapacity = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            while (line != "Statistics")
            {
                string[] commandData = line
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "Add")
                {
                    string name = commandData[1];
                    int sendedMessages = int.Parse(commandData[2]);
                    int receivedMessages = int.Parse(commandData[3]);

                    if (!usersByName.ContainsKey(name))
                    {
                        User user = new User(name, sendedMessages, receivedMessages);

                        usersByName.Add(name, user);
                    }
                }
                else if (command == "Message")
                {
                    string sender = commandData[1];
                    string receiver = commandData[2];

                    if (usersByName.ContainsKey(sender) &&
                        usersByName.ContainsKey(receiver))
                    {
                        usersByName[sender].SentedMessages++;
                        usersByName[receiver].ReceivedMessages++;

                        if (usersByName[sender].TotalMessages == messagesCapacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            
                            usersByName.Remove(sender);
                        }
                        
                        if (usersByName[receiver].TotalMessages == messagesCapacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            
                            usersByName.Remove(receiver);
                        }
                    }
                }
                else if (command == "Empty")
                {
                    string username = commandData[1];

                    if (username == "All")
                    {
                        usersByName.Clear();
                    }
                    else if (usersByName.ContainsKey(username))
                    {
                        usersByName.Remove(username);
                    }
                }

                line = Console.ReadLine();
            }

            usersByName = usersByName
                .OrderByDescending(u => u.Value.ReceivedMessages)
                .ThenBy(u => u.Value.Name)
                .ToDictionary(u => u.Key, u=> u.Value);


            Console.WriteLine($"Users count: {usersByName.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, usersByName.Values));
        }
    }
}
