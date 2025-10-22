using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Type type = typeof(String);
            //Console.WriteLine($"tür adı: { type.Name}");
            //Console.WriteLine($"namespace: {type.Namespace}");
            //Console.WriteLine($"tam adı: {type.FullName}");

            //object obj = "merhaba";
            //Type objType = obj.GetType();
            //Console.WriteLine($"nesnenin türü: { objType.Name}");


            //Type type= typeof(DateTime);
            //Console.WriteLine("metotlar:");
            //foreach(MethodInfo method in type.GetMethods())
            //{
            //    Console.WriteLine($"- {method.Name}");
            //}
            //Console.WriteLine("özellikler:");
            //foreach(PropertyInfo prop in type.GetProperties())
            //{
            //    Console.WriteLine($"- {prop.Name}");
            //}


            //Type type = typeof(Math);
            //MethodInfo method = type.GetMethod("Pow");
            //object result = method.Invoke(null, new object[] { 2, 3 });
            //Console.WriteLine($"2^3: {result}");

            //Type type = typeof(Person);
            //object personInstance = Activator.CreateInstance(type); 
            //PropertyInfo nameProperty = type.GetProperty("Name");
            //nameProperty.SetValue(personInstance, "merve");
            //string name = (string)nameProperty.GetValue(personInstance);
            //Console.WriteLine($"adı: {name}");
            //Console.ReadLine();
            

           Type type= typeof(sampleClass);
            object[] attributes = type.GetCustomAttributes(typeof(CustomAttribute),false);
            foreach (CustomAttribute attribute in attributes) 
            { 
                Console.WriteLine($"açıklama: {attribute.Description}");
            }
        }
    }
    //class Person
    //{
    //    public string Name { get; set; }

    //}
    [AttributeUsage(AttributeTargets.Class)]
    class CustomAttribute : Attribute
    {
        public string Description { get; set; }

    }
    [Custom(Description = "örnek sınıf")]
    class sampleClass
    {

    }
}
