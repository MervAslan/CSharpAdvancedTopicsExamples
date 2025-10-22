using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reflections2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Name = "Merve Aslan", Age = 22 };
            var product = new Product { ProductName = "Laptop", Price = 24500 };

            ObjectInspector.Inspect(person);
            ObjectInspector.Inspect(product);

            Console.ReadLine();

        }
    }
    public class DisplayAttribute : Attribute
    {
        public string Label { get; set; }
        public DisplayAttribute(string label)
        {
            Label = label;
        }
    }
    public class  Person
    {
        [Display("Ad Soyad")]
        public string Name { get; set; }

        [Display("Yaş")]
        public int Age { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Yaş: {Age}");
        }

    }
    public class Product
    {
        [Display("Ürün Adı")]
        public string ProductName { get; set; }
        [Display("Fiyat")]
        public decimal Price { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine($"Ürün Adı: {ProductName}, Fiyat: {Price} ₺");
        }
    }
    public class ObjectInspector
    {
        public static void Inspect(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"Sınıf: {type.Name}");
            Console.WriteLine("Özellikler:");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                var attr = prop.GetCustomAttribute<DisplayAttribute>();
                string label = attr != null ? attr.Label : prop.Name;
                object value = prop.GetValue(obj);
                Console.WriteLine($" - {label}: {value}");
            }

            Console.WriteLine("\nMetotlar:");
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($" - {method.Name}");
            }

            
            MethodInfo printMethod = type.GetMethod("PrintInfo");
            if (printMethod != null)
            {
                Console.WriteLine("\nPrintInfo() çıktısı:");
                printMethod.Invoke(obj, null);
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
