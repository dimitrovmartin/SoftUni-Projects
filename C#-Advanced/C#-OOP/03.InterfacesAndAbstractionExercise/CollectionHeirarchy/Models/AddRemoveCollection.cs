using CollectionHeirarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> items;

        public AddRemoveCollection()
        {
            items = new List<string>();
        }

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
                string item = items[items.Count - 1];

                items.RemoveAt(items.Count - 1);

                return item;
        }
    }
}
