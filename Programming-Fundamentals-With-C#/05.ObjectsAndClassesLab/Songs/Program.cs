using System;
using System.Collections.Generic;

namespace Songs
{
    public class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] songData = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);

                string songType = songData[0];
                string songName = songData[1];
                string songTime = songData[2];

                Song song = new Song(songType, songName, songTime);

                songs.Add(song);
            }

            string type = Console.ReadLine();

            foreach (var song in songs)
            {
                if (type == "all")
                {
                    Console.WriteLine(song.Name);
                }
                else
                {
                    if (song.TypeList == type)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
