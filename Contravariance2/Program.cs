class Animal { }
class Dog : Animal { }
interface IConsumer<in T>
{
    void Consume(T item); // T input olarak kullanılıyor
}

class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal item)
    {
        Console.WriteLine("Consumed: " + item.GetType().Name);
    }
}

class Program
{
    static void Main()
    {
        IConsumer<Dog> dogConsumer = new AnimalConsumer(); //Contravariance
        dogConsumer.Consume(new Dog()); 
    }
}
