using CollectionHeirarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirarchy.Models
{
    class MyList : IMyList
    {
        private List<string> items;

        public MyList()
        {
            items = new List<string>();
        }

        public int Used => items.Count;

        public int Add(string item)
        {
            if (items.Count == 0)
            {
                items.Add(item);
            }
            else
            {
                items.Insert(0, item);
            }

            return items.IndexOf(item);
        }

        public string Remove()
        {
                string item = items[0];

                items.RemoveAt(0);

                return item;
        }
    }
}
