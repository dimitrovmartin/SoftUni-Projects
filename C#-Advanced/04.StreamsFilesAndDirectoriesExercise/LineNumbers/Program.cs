using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "../../../text.txt";
            string outputPath = "../../../output.txt";

            string[] filesInfo = File.ReadAllLines(inputPath);
            List<string> outputData = new List<string>();
            int counter = 0;

            foreach (var file in filesInfo)
            {
                counter++;

                int punctuationCount = Regex.Matches(file, @"[.,;:?!'-]").Count;
                int lettersCount = Regex.Matches(file, @"[A-Za-z]").Count;

                outputData.Add($"Line {counter}: {file} ({lettersCount})({punctuationCount})");
            }

            File.WriteAllLines(outputPath, outputData);
        }
    }
}
