using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>>();

            string[] files = Directory.GetFiles("../../../");

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                string currentFile = info.Name;

                int startIndex = currentFile.LastIndexOf(".");
                string fileType = currentFile.Substring(startIndex);

                if (!result.ContainsKey(fileType))
                {
                    result.Add(fileType, new Dictionary<string, double>());
                }
                using (FileStream stream = new FileStream($"../../../{currentFile}", FileMode.Open))
                {
                    result[fileType].Add(currentFile, stream.Length / 100d);
                }

                result = result.OrderByDescending(x => x.Value.Values.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath
                    (Environment.SpecialFolder.Desktop)}\report.txt"))
                {
                    foreach (var extention in result)
                    {
                        writer.WriteLine(extention.Key);
                        foreach (var file1 in extention.Value.OrderBy(x => x.Value))
                        {
                            writer.WriteLine($"--{file1.Key} - {file1.Value}kb");
                        }
                    }
                }
            }
        }
    }
}
