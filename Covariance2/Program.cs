using System;

class Animal { }
class Dog : Animal { }

delegate Animal CreateAnimal(); // Covariant delegate

class Program
{
    static Dog CreateDog() => new Dog();

    static void Main()
    {
        // Covariance: Dog döndüren metodu, Animal döndüren delegate'e atadık
        CreateAnimal factory = CreateDog;

        Animal a = factory();
        Console.WriteLine(a.GetType().Name); 
    }
}
