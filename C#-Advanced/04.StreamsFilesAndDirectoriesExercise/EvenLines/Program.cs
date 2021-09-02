using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                text = reader.ReadToEnd();
            }

            char[] symbols = new char[] { ',', '.', '-', '?', '!', '\'' };

            foreach (var symbol in symbols)
            {
                text = text.Replace(symbol, '@');
            }

            string[] splittedText = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            char[] splitter = new char[] { ',', '.', '-', '?', '!', '\'', ' ' };

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                for (int i = 0; i < splittedText.Length; i += 2)
                {
                    string[] reversedText = splittedText[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries).Reverse()
                        .ToArray();

                    foreach (var word in reversedText)
                    {
                        writer.Write(word + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}

