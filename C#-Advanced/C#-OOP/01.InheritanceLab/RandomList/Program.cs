using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList list = new RandomList();

            for (int i = 0; i < 10; i++)
            {
                list.Add($"{i}");
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
