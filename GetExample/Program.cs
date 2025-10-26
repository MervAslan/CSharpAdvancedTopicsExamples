using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var client = new HttpClient(); // HttpClient nesnesi oluşturduk
        var url = "https://jsonplaceholder.typicode.com/todos/1"; // GET isteği atacağımız API
        var response = await client.GetAsync(url); // GET isteğini gönderiyoruz
        var content = await response.Content.ReadAsStringAsync(); // Gelen cevabı string olarak alıyoruz
        Console.WriteLine("GET Response:");
        Console.WriteLine(content); // Ekrana yazdırıyoruz
    }
}
