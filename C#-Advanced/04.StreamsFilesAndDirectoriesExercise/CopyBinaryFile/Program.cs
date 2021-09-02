using System;
using System.IO;
using System.Linq;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../copiedPng.png", FileMode.Create))
                {
                    while (reader.Position != reader.Length)
                    {
                        byte[] buffer = new byte[4096];

                        reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
