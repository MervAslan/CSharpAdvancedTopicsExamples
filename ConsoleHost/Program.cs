using ConsoleHost.ServiceReference1;
using System;


class Program
{
    static void Main()
    {
        var client = new ServiceClient();

        Console.WriteLine(client.SayHello("merve"));

        var newUser = new User { Name = "merve", Email = "merve44@gmail.com" };
        client.AddUser(newUser);

        Console.WriteLine(client.SayHelloJson("ali"));
        var user2 = new User { Name = "ali", Email = "ali42@gmail.com" };
        client.AddUserJson(user2);

        var users = client.GetAllUsers();
        foreach (var u in users)
            Console.WriteLine($"{u.Id} - {u.Name} ({u.Email})");

        client.Close();
        Console.ReadLine();
    }
}



