using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int currentIndex;

        public ListyIterator(params T[] list)
        {
            this.list = new List<T>(list);

            currentIndex = 0;
        }

        public bool Move()
        {
            if (currentIndex + 1 < list.Count)
            {
                currentIndex++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext() => currentIndex + 1 < list.Count;

        public void Print()
        {
            if (list.Count > 0 && currentIndex < list.Count)
            {
                Console.WriteLine(list[currentIndex]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
