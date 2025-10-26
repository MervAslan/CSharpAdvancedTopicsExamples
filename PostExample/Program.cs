using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var client = new HttpClient();
        var url = "https://jsonplaceholder.typicode.com/posts";

        var jsonData = "{ \"title\": \"foo\", \"body\": \"bar\", \"userId\": 1 }";
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json"); // JSON veriyi hazırlıyoruz

        var response = await client.PostAsync(url, content); // POST isteğini gönderiyoruz
        var responseContent = await response.Content.ReadAsStringAsync(); // Gelen cevabı alıyoruz

        Console.WriteLine("POST Response:");
        Console.WriteLine(responseContent);
    }
}
