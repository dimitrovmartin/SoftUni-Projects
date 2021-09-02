using System;
using System.IO;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                for (int i = 0; i < 4; i++)
                {
                    using (FileStream writer = new FileStream($"../../../Output{i + 1}.txt",FileMode.Create))
                    {
                        byte[] buffer = new byte[reader.Length / 4];
                        reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
