using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("../../../Input.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
                {
                    string line = streamReader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            streamWriter.WriteLine(line);
                        }

                        counter++;

                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
