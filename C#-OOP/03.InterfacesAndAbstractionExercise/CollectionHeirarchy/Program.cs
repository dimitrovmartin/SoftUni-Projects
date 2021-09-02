using CollectionHeirarchy.Contracts;
using CollectionHeirarchy.Models;
using System;

namespace CollectionHeirarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(addCollection.Add(data[i]) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(addRemoveCollection.Add(data[i]) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(myList.Add(data[i]) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
