namespace _01.DogVet
{
    using System.Collections.Generic;

    public interface IDogVet
    {
        int Size { get; }

        void AddDog(Dog dog, Owner owner);

        bool Contains(Dog dog);

        Dog GetDog(string name, string ownerId);

        Dog RemoveDog(string name, string ownerId);

        IEnumerable<Dog> GetDogsByOwner(string ownerId);

        IEnumerable<Dog> GetDogsByBreed(Breed breed);

        void Vaccinate(string name, string ownerId);

        void Rename(string oldName, string newName, string ownerId);

        IEnumerable<Dog> GetAllDogsByAge(int age);

        IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi);

        IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending();
    }
}