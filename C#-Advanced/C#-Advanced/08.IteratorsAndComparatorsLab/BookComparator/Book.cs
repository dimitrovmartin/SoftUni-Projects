using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            if (Year.CompareTo(other.Year) != 0)
            {
                return Year.CompareTo(other.Year);
            }
            else
            { 
                return Title.CompareTo(other.Title);
            }
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
