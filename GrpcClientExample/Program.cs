using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServerExample; // namespace proto’dan geliyor

class Program
{
    static async Task Main(string[] args)
    {
        // Sunucuya bağlan (adres Visual Studio’daki server port’unla aynı olmalı)
        using var channel = GrpcChannel.ForAddress("https://localhost:7180");
        var client = new Greeter.GreeterClient(channel);

        // Servis metodunu çağır
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "Merve" });

        Console.WriteLine(reply.Message);
    }
}
