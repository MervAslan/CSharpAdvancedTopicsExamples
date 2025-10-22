using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            // IReportable implement eden class’ları bul
            var reportTypes = asm.GetTypes()
                .Where(t => typeof(IReportable).IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            Console.WriteLine("Mevcut sınıflar:");
            for (int i = 0; i < reportTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reportTypes[i].Name}");
            }

            Console.Write("Hangi sınıfı çalıştırmak istersiniz? (numara): ");
            int choice = int.Parse(Console.ReadLine() ?? "1");
            Type selectedType = reportTypes[choice - 1];

            // Instance oluştur
            object instance = Activator.CreateInstance(selectedType);

            // Özellikleri doldur (örnek)
            foreach (var prop in selectedType.GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                    prop.SetValue(instance, "Deneme");
                if (prop.PropertyType == typeof(int))
                    prop.SetValue(instance, 123);
                if (prop.PropertyType == typeof(decimal))
                    prop.SetValue(instance, 999m);
            }

            // [ReportMethod] attribute’lu metodları çalıştır
            var methods = selectedType.GetMethods()
                .Where(m => m.GetCustomAttribute<ReportMethodAttribute>() != null);

            foreach (var method in methods)
            {
                method.Invoke(instance, null);
            }

            Console.ReadLine();
        }
    }
    public interface IReportable { }

    [AttributeUsage(AttributeTargets.Method)]
    public class ReportMethodAttribute : Attribute
    {
       
    }
    public class Employee : IReportable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [ReportMethod]
        public void GenerateReport()
        {
            Console.WriteLine($"Generating report for employee: {Name}, Age: {Age}");
        }
    }
    public class Product : IReportable
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        [ReportMethod]
        public void GenerateReport()
        {
            Console.WriteLine($"Product Rapor: {ProductName}, Fiyat: {Price} tl");
        }
    }
}
