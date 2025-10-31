using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


public class Service : IService
{
    
    public Person GetPerson(string name)
    {
        return new Person { Name = name, Age = 22 };
    }

    public string SayHello(string name)
    {
        return "merhaba "+ name;
    }
}
