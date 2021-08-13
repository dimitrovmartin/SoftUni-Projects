using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }

        public void ChangeKey(string newKey)
        {
            Key = newKey;
        }

        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> piecesByName = new Dictionary<string, Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] pieceData = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string pieceName = pieceData[0];
                string pieceComposer = pieceData[1];
                string pieceKey = pieceData[2];

                if (!piecesByName.ContainsKey(pieceName))
                {
                    Piece piece = new Piece(pieceName, pieceComposer, pieceKey);

                    piecesByName.Add(pieceName, piece);
                }
            }

            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string[] commandData = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string pieceName = commandData[1];

                if (command == "Add")
                {
                    string pieceComposer = commandData[2];
                    string pieceKey = commandData[3];

                    if (piecesByName.ContainsKey(pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        Piece piece = new Piece(pieceName, pieceComposer, pieceKey);

                        piecesByName.Add(pieceName, piece);

                        Console.WriteLine($"{pieceName} by {pieceComposer} in {pieceKey} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (piecesByName.ContainsKey(pieceName))
                    {
                        piecesByName.Remove(pieceName);

                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = commandData[2];

                    if (piecesByName.ContainsKey(pieceName))
                    {
                        piecesByName[pieceName].ChangeKey(newKey);

                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }

                line = Console.ReadLine();
            }

            piecesByName = piecesByName
                .OrderBy(p => p.Value.Name)
                .ThenBy(p => p.Value.Composer)
                .ToDictionary(p => p.Key, p => p.Value);

            Console.WriteLine(string.Join(Environment.NewLine, piecesByName.Values));
        }
    }
}
