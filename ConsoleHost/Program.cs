using ConsoleHost.ServiceReference1;
using System;
 

class Program
{
    static void Main()
    {
        var client = new ServiceClient();

        string merhaba = client.SayHello("merve");
        Console.WriteLine(merhaba);

        var person = client.GetPerson("ali");
        Console.WriteLine($"isim: {person.Name}, yaş: {person.Age}");

    }
}
