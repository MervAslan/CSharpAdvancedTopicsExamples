using System;

class Animal { }
class Dog : Animal { }

// Covariant generic interface
interface IProducer<out T>
{
    T Produce();
}

class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog();
}

class Program
{
    static void Main()
    {
        // Covariance: IProducer<Dog> → IProducer<Animal>
        IProducer<Dog> dogProducer = new DogProducer();
        IProducer<Animal> animalProducer = dogProducer;

        Animal a = animalProducer.Produce();
        Console.WriteLine(a.GetType().Name); // Çıktı: Dog
    }
}
