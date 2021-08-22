using System;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstFilePath = "../../../FileOne.txt";
            string secondFilePath = "../../../FileTwo.txt";

            using (StreamReader firstReader = new StreamReader(firstFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondFilePath))
                {
                    using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
                    {
                        string firstLine = firstReader.ReadLine();
                        string secondLine = secondReader.ReadLine();

                        while (firstLine != null || secondLine != null)
                        {
                            if (firstLine != null)
                            {
                                streamWriter.WriteLine(firstLine);
                            }

                            if (secondLine != null)
                            {
                                streamWriter.WriteLine(secondLine);
                            }

                            firstLine = firstReader.ReadLine();
                            secondLine = secondReader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
