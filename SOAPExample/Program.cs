using CalculatorService;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // soap servisine bağlanıyoruz
        var client = new CalculatorSoapClient(
            CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);

        
        int result = await client.AddAsync(10, 5);

        Console.WriteLine($"10 + 5 = {result}");

        // işimiz bitince client'ı kapatıyoruz
        await client.CloseAsync();
    }
}
