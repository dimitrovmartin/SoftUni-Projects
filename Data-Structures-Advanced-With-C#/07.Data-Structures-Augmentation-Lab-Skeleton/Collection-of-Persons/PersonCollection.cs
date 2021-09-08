namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private Dictionary<string, Person> personsByEmail;
        private Dictionary<string, SortedSet<Person>> personsByEmailDomains;
        private Dictionary<string, SortedSet<Person>> personsByNameAndTown;
        private OrderedDictionary<int, SortedSet<Person>> personsByAge;
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge;

        public PersonCollection()
        {
            personsByEmail = new Dictionary<string, Person>();
            personsByEmailDomains = new Dictionary<string, SortedSet<Person>>();
            personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
            personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
            personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (!personsByEmail.ContainsKey(email))
            {
                string domain = email.Split('@')[1];

                Person person = new Person()
                {
                    Name = name,
                    Age = age,
                    Email = email,
                    Town = town
                };

                personsByEmail.Add(email, person);

                if (!personsByEmailDomains.ContainsKey(domain))
                {
                    personsByEmailDomains.Add(domain, new SortedSet<Person>());
                }

                personsByEmailDomains[domain].Add(person);

                if (!personsByNameAndTown.ContainsKey(name + town))
                {
                    personsByNameAndTown.Add(name + town, new SortedSet<Person>());
                }

                personsByNameAndTown[name + town].Add(person);

                if (!personsByAge.ContainsKey(age))
                {
                    personsByAge.Add(age, new SortedSet<Person>());
                }

                if (!personsByAge.ContainsKey(age))
                {
                    personsByAge.Add(age, new SortedSet<Person>());
                }

                personsByAge[age].Add(person);

                if (!personsByTownAndAge.ContainsKey(town))
                {
                    personsByTownAndAge.Add(town, new OrderedDictionary<int, SortedSet<Person>>());
                }

                if (!personsByTownAndAge[town].ContainsKey(age))
                {
                    personsByTownAndAge[town].Add(age, new SortedSet<Person>());
                }

                personsByTownAndAge[town][age].Add(person);


                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count => personsByEmail.Count;
        public Person FindPerson(string email)
        {
            if (personsByEmail.ContainsKey(email))
            {
                return personsByEmail[email];
            }

            return null;
        }

        public bool DeletePerson(string email)
        {
            if (personsByEmail.ContainsKey(email))
            {
                string domain = email.Split('@')[1];

                Person person = FindPerson(email);

                personsByEmail.Remove(email);
                personsByEmailDomains[domain].Remove(person);
                personsByNameAndTown[person.Name + person.Town].Remove(person);
                personsByAge[person.Age].Remove(person);
                personsByTownAndAge[person.Town][person.Age].Remove(person);

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            if (personsByEmailDomains.ContainsKey(emailDomain))
            {
                return personsByEmailDomains[emailDomain];
            }
            else
            {
                return new SortedSet<Person>();
            }
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            if (personsByNameAndTown.ContainsKey(name + town))
            {
                return personsByNameAndTown[name + town];
            }
            else
            {
                return new SortedSet<Person>();
            }
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            List<Person> toReturn = new List<Person>();
            foreach (var age in personsByAge)
            {
                if (age.Key >= startAge && age.Key <= endAge)
                {
                    toReturn.AddRange(age.Value);
                }
            }

            return toReturn;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            List<Person> toReturn = new List<Person>();

            if (personsByTownAndAge.ContainsKey(town))
            {
                foreach (var collection in personsByTownAndAge[town])
                {
                    if (collection.Key >= startAge && collection.Key <= endAge)
                    {
                        toReturn.AddRange(collection.Value);
                    }
                }
            }

            return toReturn;
        }
    }
}
