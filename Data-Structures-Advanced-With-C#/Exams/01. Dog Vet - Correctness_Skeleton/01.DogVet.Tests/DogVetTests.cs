namespace _01.DogVet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using _01.DogVet;

    public class DogVetTests
    {
        private DogVet dogVet;
        private Dog d1;
        private Dog d2;
        private Dog d3;
        private Dog d4;
        private Owner o1;
        private Owner o2;

        [SetUp]
        public void Setup()
        {
            dogVet = new DogVet();
            this.d1 = new Dog("1", "a", Breed.Bulldog, 1, 0);
            this.d2 = new Dog("2", "b", Breed.CockerSpaniel, 1, 1);
            this.d3 = new Dog("3", "a", Breed.GermanShepherd, 0, 2);
            this.d4 = new Dog("4", "c", Breed.Bulldog, 1, 5);
            this.o1 = new Owner("1", "a");
            this.o2 = new Owner("2", "a");
        }

        [Test]
        public void TestAdd()
        {
            dogVet.AddDog(d1, o1);

            Assert.AreEqual(dogVet.Size, 1);
            Assert.True(dogVet.Contains(d1));
        }

        [Test]
        public void TestAddAndGet()
        {
            dogVet.AddDog(d1, o1);


            var d = dogVet.GetDog(d1.Name, o1.Id);
            Assert.AreEqual(d, d1);
        }

        [Test]
        public void TestAddSameDog()
        {
            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.AddDog(d1, o1);
                dogVet.AddDog(d1, o1);
            });
        }

        [Test]
        public void TestAddDogsOneOwnerSameName()
        {
            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.AddDog(d1, o1);
                dogVet.AddDog(new Dog("2", d1.Name, Breed.Bulldog, 1, 1), o1);
            });
        }

        [Test]
        public void TestContainsDogReturnTrue()
        {
            dogVet.AddDog(d1, o1);
            Assert.True(dogVet.Contains(d1));
        }


        [Test]
        public void TestContainsDogReturnFalse()
        {
            dogVet.AddDog(d1, o1);
            Assert.False(dogVet.Contains(new Dog("2", "asd", Breed.CockerSpaniel, 1, 1)));
        }

        [Test]
        public void TestSizeZeroDogs()
        {
            Assert.AreEqual(0, dogVet.Size);
        }

        [Test]
        public void TestSizeOneDogs()
        {
            dogVet.AddDog(d1, o1);
            Assert.AreEqual(1, dogVet.Size);
        }

        [Test]
        public void TestSizeMultipleDogs()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.AreEqual(3, dogVet.Size);
        }

        [Test]
        public void TestGetDog()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Dog dog = dogVet.GetDog("a", "1");
            Assert.AreEqual(dog, d1);
        }

        [Test]
        public void TestGetNonExistentDog()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.Throws<ArgumentException>(delegate ()
            {
                Dog dog = dogVet.GetDog("z", "1");
            });
        }

        [Test]
        public void TestGetNonExistentOwner()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.Throws<ArgumentException>(delegate ()
            {
                Dog dog = dogVet.GetDog("a", "10");
            });
        }

        [Test]
        public void TestRemoveDog()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.AreEqual(d1, dogVet.RemoveDog("a", "1"));
        }

        [Test]
        public void TestRemoveDogOwnerShouldOwnIt()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.AreEqual(d1, dogVet.RemoveDog("a", "1"));
            Assert.Throws<ArgumentException>(delegate ()
            {
                Dog dog = dogVet.GetDog("a", "1");
            });
            Assert.AreEqual(2, dogVet.Size);
            dogVet.AddDog(d1, o1);
            Assert.AreEqual(3, dogVet.Size);
        }

        [Test]
        public void TestRemoveMultiple()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.AreEqual(d1, dogVet.RemoveDog("a", "1"));
            Assert.AreEqual(d2, dogVet.RemoveDog("b", "1"));
            Assert.AreEqual(d3, dogVet.RemoveDog("a", "2"));

            Assert.AreEqual(0, dogVet.Size);
        }

        [Test]
        public void TestRemoveDogNonExistentOwner()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.RemoveDog("1", "asd");
            });
        }

        [Test]
        public void TestGetDogsByOwnerOnly1Dog()
        {
            dogVet.AddDog(d1, o1);

            IEnumerable<Dog> dogs = dogVet.GetDogsByOwner("1");
            List<Dog> list = new List<Dog> { d1 };

            CollectionAssert.AreEquivalent(dogs, list);
        }


        [Test]
        public void TestGetDogsByOwner()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            IEnumerable<Dog> dogs = dogVet.GetDogsByOwner("1");
            List<Dog> list = new List<Dog> { d1, d2 };

            CollectionAssert.AreEquivalent(dogs, list);
        }

        [Test]
        public void TestGetDogsByOwnerMultipleOperations()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            IEnumerable<Dog> dogs = dogVet.GetDogsByOwner("1");
            List<Dog> list = new List<Dog> { d1, d2 };

            CollectionAssert.AreEquivalent(dogs, list);

            dogVet.RemoveDog("a", "1");

            dogs = dogVet.GetDogsByOwner("1");
            list = new List<Dog> { d2 };
            CollectionAssert.AreEquivalent(dogs, list);
        }

        [Test]
        public void TestGetDogsByBreedEmpty()
        {
            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.GetDogsByBreed(Breed.CockerSpaniel);
            });
        }

        [Test]
        public void TestGetDogsByBreedOneOnly()
        {
            dogVet.AddDog(d1, o1);

            var dogs = dogVet.GetDogsByBreed(Breed.Bulldog);

            CollectionAssert.AreEqual(new List<Dog>() { d1 }, dogs);
        }

        [Test]
        public void TestGetDogsByBreedMultiple()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d4, o2);

            var dogs = dogVet.GetDogsByBreed(Breed.Bulldog);

            CollectionAssert.AreEqual(new List<Dog>() { d1, d4 }, dogs);
        }

        [Test]
        public void TestGetDogsByBreedMultipleOperations()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d4, o1);

            var dogs = dogVet.GetDogsByBreed(Breed.Bulldog);
            CollectionAssert.AreEqual(new List<Dog>() { d1, d4 }, dogs);

            dogVet.RemoveDog(d4.Name, o1.Id);

            dogs = dogVet.GetDogsByBreed(Breed.Bulldog);
            CollectionAssert.AreEqual(new List<Dog>() { d1 }, dogs);
        }

        [Test]
        public void TestVaccinate()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            dogVet.Vaccinate(d1.Name, o1.Id);
            dogVet.Vaccinate(d3.Name, o2.Id);

            var dd1 = dogVet.GetDog(d1.Name, o1.Id);
            var dd2 = dogVet.GetDog(d3.Name, o2.Id);

            Assert.AreEqual(dd1.Vaccines, 1);
            Assert.AreEqual(dd2.Vaccines, 3);
        }

        [Test]
        public void TestVaccinateNonExistedDog()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.Vaccinate("asdasdasd", o1.Id);
            });
        }

        [Test]
        public void TestVaccinateNonExistedOwner()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.Vaccinate(d1.Name, "pesho");
            });
        }

        [Test]
        public void TestRename()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);

            dogVet.Rename(d1.Name, "pesho", o1.Id);
            dogVet.Rename(d2.Name, "gosho", o1.Id);

            Assert.AreEqual("pesho", dogVet.GetDog("pesho", o1.Id).Name);
            Assert.AreEqual("gosho", dogVet.GetDog("gosho", o1.Id).Name);
            var dd = dogVet.GetDog(d3.Name, o2.Id).Name;
            Assert.AreEqual(d3.Name, dogVet.GetDog(d3.Name, o2.Id).Name);
        }

        [Test]
        public void TestGetAnimalsByAgeNon()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            Assert.Throws<ArgumentException>(delegate ()
            {
                dogVet.GetAllDogsByAge(-1);
            });
        }

        [Test]
        public void TestGetAnimalsByAgeOnlyOne()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            var ddds = dogVet.GetAllDogsByAge(0);
            var expected = new List<Dog>() { d3 };

            CollectionAssert.AreEquivalent(ddds, expected);
        }

        [Test]
        public void TestGetAnimalsByAgeMultiple()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            var ddds = dogVet.GetAllDogsByAge(1);
            var expected = new List<Dog>() { d1, d2, d4 };

            CollectionAssert.AreEquivalent(ddds, expected);
        }

        [Test]
        public void GetAllAnimalsInAgeRangeNon()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            List<Dog> dogs = dogVet.GetDogsInAgeRange(5, 10).ToList();
            Assert.AreEqual(0, dogs.Count);
        }

        [Test]
        public void GetAllAnimalsInAgeRangeFindOne()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            List<Dog> dogs = dogVet.GetDogsInAgeRange(0, 0).ToList();
            Assert.AreEqual(1, dogs.Count);
        }

        [Test]
        public void GetAllAnimalsInAgeRangeFindAll()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            List<Dog> dogs = dogVet.GetDogsInAgeRange(0, 1).ToList();
            Assert.AreEqual(4, dogs.Count);
        }

        [Test]
        public void TestGetAllOrderedByAgeThenByNameThenByOwnerNameAscendingV1()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);

            var dogs = dogVet.GetAllOrderedByAgeThenByNameThenByOwnerNameAscending().ToList();
        }

        [Test]
        public void TestGetAllOrderedByAgeThenByNameThenByOwnerNameAscendingV2()
        {
            dogVet.AddDog(d1, o1);
            dogVet.AddDog(d2, o1);
            dogVet.AddDog(d3, o2);
            dogVet.AddDog(d4, o2);
            var o3 = new Owner("3", "x");
            var o4 = new Owner("4", "z");

            var d5 = new Dog("5", "d", Breed.CockerSpaniel, 0, 0);
            var d6 = new Dog("6", "d", Breed.CockerSpaniel, 0, 0);
            var d7 = new Dog("7", "h", Breed.CockerSpaniel, 0, 5);
            var d8 = new Dog("8", "g", Breed.CockerSpaniel, 0, 3);
            var d9 = new Dog("9", "h", Breed.CockerSpaniel, 0, 31);
            var d10 = new Dog("10", "i", Breed.CockerSpaniel, 0, 1);
            var d11 = new Dog("11", "g", Breed.CockerSpaniel, 0, 2);
            var d12 = new Dog("12", "k", Breed.CockerSpaniel, 0, 0);

            dogVet.AddDog(d5, o2);
            dogVet.AddDog(d6, o3);
            dogVet.AddDog(d7, o4);
            dogVet.AddDog(d8, o1);
            dogVet.AddDog(d9, o2);
            dogVet.AddDog(d10, o3);
            dogVet.AddDog(d11, o4);
            dogVet.AddDog(d12, o1);

            var dogs = dogVet.GetAllOrderedByAgeThenByNameThenByOwnerNameAscending().ToList();

            var expected = new List<Dog>() {
                d3, d5, d6, d8, d11, d9, d7, d10, d12, d1, d2, d4
            };

            CollectionAssert.AreEqual(dogs, expected);
        }
    }
}
