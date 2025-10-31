using System;
using System.Collections.Generic;

class Animal { }
class Dog : Animal { }

class Program
{
    static void Main()
    {
        IEnumerable<Dog> dogs = new List<Dog>
        {
            new Dog(),
            new Dog()
        };

        IEnumerable<Animal> animals = dogs; // covariance

        foreach (Animal a in animals)
        {
            Console.WriteLine(a.GetType().Name); // "Dog" yazar
        }
    }
}
