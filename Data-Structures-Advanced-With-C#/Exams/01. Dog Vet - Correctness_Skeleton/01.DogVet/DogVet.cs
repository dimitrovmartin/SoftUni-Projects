namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dog> dogsById;
        private Dictionary<string, Owner> ownersById;
        private Dictionary<string, HashSet<string>> dogsNamesByOwnerId;
        private Dictionary<string, Dictionary<string, Dog>> dogsByNamesByOwnerId;
        private Dictionary<string, HashSet<Dog>> dogsByBreed;
        private SortedDictionary<int, List<Dog>> dogsByAge;

        public DogVet()
        {
            dogsById = new Dictionary<string, Dog>();
            ownersById = new Dictionary<string, Owner>();
            dogsNamesByOwnerId = new Dictionary<string, HashSet<string>>();
            dogsByNamesByOwnerId = new Dictionary<string, Dictionary<string, Dog>>();
            dogsByBreed = new Dictionary<string, HashSet<Dog>>();
            dogsByAge = new SortedDictionary<int, List<Dog>>();
        }

        public int Size => dogsById.Count;

        public void AddDog(Dog dog, Owner owner)
        {
            if (dogsById.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }

            if (ownersById.ContainsKey(owner.Id))
            {
                if (dogsNamesByOwnerId[owner.Id].Contains(dog.Name))
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                ownersById.Add(owner.Id, owner);
                dogsNamesByOwnerId.Add(owner.Id, new HashSet<string>());
                dogsByNamesByOwnerId.Add(owner.Id, new Dictionary<string, Dog>());
            }

            if (!dogsByBreed.ContainsKey(dog.Breed.ToString()))
            {
                dogsByBreed.Add(dog.Breed.ToString(), new HashSet<Dog>());
            }

            if (!dogsByAge.ContainsKey(dog.Age))
            {
                dogsByAge.Add(dog.Age, new List<Dog>());
            }

            dog.Owner = owner;
            dogsById.Add(dog.Id, dog);
            dogsNamesByOwnerId[owner.Id].Add(dog.Name);
            dogsByNamesByOwnerId[owner.Id].Add(dog.Name, dog);
            dogsByBreed[dog.Breed.ToString()].Add(dog);
            dogsByAge[dog.Age].Add(dog);
        }

        public bool Contains(Dog dog)
        {
            return dogsById.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (dogsByNamesByOwnerId.ContainsKey(ownerId) && dogsByNamesByOwnerId[ownerId].ContainsKey(name))
            {
                return dogsByNamesByOwnerId[ownerId][name];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (dogsByNamesByOwnerId.ContainsKey(ownerId) && dogsByNamesByOwnerId[ownerId].ContainsKey(name))
            {
                Dog dog = dogsByNamesByOwnerId[ownerId][name];

                dogsById.Remove(dog.Id);
                dogsByNamesByOwnerId[ownerId].Remove(name);
                dogsNamesByOwnerId[ownerId].Remove(name);
                dogsByBreed[dog.Breed.ToString()].Remove(dog);
                dogsByAge[dog.Age].Remove(dog);

                return dog;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (ownersById.ContainsKey(ownerId))
            {
                return dogsByNamesByOwnerId[ownerId].Values;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            if (dogsByBreed.ContainsKey(breed.ToString()) && dogsByBreed[breed.ToString()].Count > 0)
            {
                return dogsByBreed[breed.ToString()];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (dogsByNamesByOwnerId.ContainsKey(ownerId) && dogsByNamesByOwnerId[ownerId].ContainsKey(name))
            {
                Dog dog = dogsByNamesByOwnerId[ownerId][name];

                dog.Vaccines++;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (dogsByNamesByOwnerId.ContainsKey(ownerId) && dogsByNamesByOwnerId[ownerId].ContainsKey(oldName))
            {
                Dog dog = dogsByNamesByOwnerId[ownerId][oldName];

                dog.Name = newName;

                dogsByNamesByOwnerId[ownerId].Remove(oldName);
                dogsByNamesByOwnerId[ownerId].Add(newName, dog);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            if (dogsByAge.ContainsKey(age) && dogsByAge[age].Count > 0)
            {
                return dogsByAge[age];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            List<Dog> dogs = new List<Dog>();

            for (int i = lo; i <= hi; i++)
            {
                if (dogsByAge.ContainsKey(i))
                {
                    dogs.AddRange(dogsByAge[i]);
                }
            }

            return dogs;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return dogsById.Values
                .OrderBy(d => d.Age)
                .ThenBy(d => d.Name)
                .ThenBy(d => d.Owner.Name);
        }
    }
}