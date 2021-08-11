using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string line = Console.ReadLine();

            while (line != "Statistics")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vlogger = commandData[0];
                string command = commandData[1];

                if (command == "joined")
                {
                    if (!app.ContainsKey(vlogger))
                    {
                        app.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                        app[vlogger].Add("followers", new SortedSet<string>());
                        app[vlogger].Add("followings", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string followedVlogger = commandData[2];

                    if (app.ContainsKey(vlogger))
                    {
                        if (app.ContainsKey(followedVlogger) &&
                            vlogger != followedVlogger &&
                            !app[vlogger]["followings"].Contains(followedVlogger))
                        {
                            app[vlogger]["followings"].Add(followedVlogger);
                            app[followedVlogger]["followers"].Add(vlogger);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            app = app
                .OrderByDescending(v => v.Value["followers"].Count)
                .ThenBy(v => v.Value["followings"].Count)
                .ToDictionary(v => v.Key, v => v.Value);

            int counter = 1;

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            foreach (var vlogger in app)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["followings"].Count} following");

                if (counter == 1)
                {
                    foreach (var followedVlogger in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {followedVlogger}");
                    }
                }

                counter++;
            }
        }
    }
}
