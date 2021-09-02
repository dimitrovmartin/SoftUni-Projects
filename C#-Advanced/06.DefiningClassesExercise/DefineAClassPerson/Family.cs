using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family;

        public Family()
        {
            family = new List<Person>();
        }

        public void AddMember(Person person)
        {
            family.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = family.OrderByDescending(p => p.Age).FirstOrDefault();

            return oldestMember;
        }
    }
}
