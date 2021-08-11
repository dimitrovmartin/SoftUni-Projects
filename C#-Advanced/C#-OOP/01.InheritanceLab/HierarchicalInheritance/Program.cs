using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();

            dog.Eat();
            dog.Bark();

            cat.Eat();
            cat.Meow();
        }
    }
}
