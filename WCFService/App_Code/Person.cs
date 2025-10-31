using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Web;

[DataContract]
public class Person
{
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public int Age { get; set; }
}