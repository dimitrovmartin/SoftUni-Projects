using System;
using System.IO;

namespace LineNumbers
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
                    int counter = 1;

                    while (line != null)
                    {
                        streamWriter.WriteLine($"{counter}. {line}");

                        counter++;

                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
