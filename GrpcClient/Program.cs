using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
#pragma warning disable CS0436 // Type conflicts with imported type
            var input = new HelloRequest { Name = "Dawid" };
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
#pragma warning restore CS0436 // Type conflicts with imported type

            var response = await client.SayHelloAsync(input);

            Console.WriteLine(response.Message);

            Console.ReadLine();
        }
    }
}
