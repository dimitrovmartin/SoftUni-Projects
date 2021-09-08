namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;

    public class PersonCollectionSlow : IPersonCollection
    {
        // TODO: define the underlying data structures here ...

        public bool AddPerson(string email, string name, int age, string town)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public Person FindPerson(string email)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            throw new NotImplementedException();
        }
    }
}
