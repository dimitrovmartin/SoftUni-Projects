using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Title.CompareTo(y.Title) != 0)
            {
                return x.Title.CompareTo(y.Title);
            }
            else
            {
                return x.Year.CompareTo(y.Year);
            }
        }
    }
}
