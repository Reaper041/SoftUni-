using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();

            Person personTwo = new Person(7);

            Person personThree = new Person("Dimitar", 17);
        }
    }
}
