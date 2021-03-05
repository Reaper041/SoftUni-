using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal animal = new Animal();
            Dog dog = new Dog();

           dog.Bark();
        }
    }
}
