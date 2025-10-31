class Animal { }
class Dog : Animal { }

delegate void AnimalHandler(Dog d); // Dog tipinde input alıyor

class Program
{
    static void HandleAnimal(Animal a)
    {
        Console.WriteLine("Handled: " + a.GetType().Name);
    }

    static void Main()
    {
        AnimalHandler handler = HandleAnimal; // ✅ Contravariance
        handler(new Dog()); 
    }
}
