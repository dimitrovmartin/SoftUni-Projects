using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allDirectories = Directory.GetFiles("../../../TestFolder");
            decimal sum = 0;

            foreach (var directory in allDirectories)
            {
                FileInfo fileInfo = new FileInfo(directory);

                sum += fileInfo.Length;
            }

            sum /= 1000000;

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                writer.Write(sum);
            }
        }
    }
}
