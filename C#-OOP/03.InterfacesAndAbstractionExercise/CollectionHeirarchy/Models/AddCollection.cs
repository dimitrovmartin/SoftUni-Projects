using CollectionHeirarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> items;

        public AddCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Add(item);

            return items.IndexOf(item);
        }
    }
}
