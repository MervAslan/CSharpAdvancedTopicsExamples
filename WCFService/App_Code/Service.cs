using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

public class Service : IService
{

    private static List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "Ali", Email = "ali@example.com" },
        new User { Id = 2, Name = "Ayşe", Email = "ayse@example.com" }
    };
    private static int _nextId = 1;

    
    public string SayHello(string name)
    {
        return "merhaba" +name + " bu bir soap endpointidir";
    }

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAllUsers()
    {
        return _users.ToList(); 
    }

    public void AddUser(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
    }

    
    public string SayHelloJson(string name)
    {
        return "merhaba " + name + " bu bir json endpointidir";
    }

    public List<User> GetAllUsersJson()
    {
        return _users.ToList();
    }

    public User AddUserJson(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }
}