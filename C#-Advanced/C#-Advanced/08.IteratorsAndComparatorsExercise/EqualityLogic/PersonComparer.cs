using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.CompareTo(y.Name);

            if (result == 0)
            {
                result = x.Age.CompareTo(y.Age);
            }

            return result;
        }
    }
}
