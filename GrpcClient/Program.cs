using Grpc.Core;
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
            //#pragma warning disable CS0436 // Type conflicts with imported type
            //            var input = new HelloRequest { Name = "Dawid" };
            //            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //            var client = new Greeter.GreeterClient(channel);
            //#pragma warning restore CS0436 // Type conflicts with imported type

            //            var response = await client.SayHelloAsync(input);

            //            Console.WriteLine(response.Message);


            //#pragma warning disable CS0436 // Type conflicts with imported type
            //            var input = new CustomerLookupModel() { CustomerId = 0 };
            //            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //            var client = new Customer.CustomerClient(channel);
            //#pragma warning restore CS0436 // Type conflicts with imported type

            //            var response = await client.GetCustomerInfoAsync(input);

            //            Console.WriteLine(response);

#pragma warning disable CS0436 // Type conflicts with imported type=
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Customer.CustomerClient(channel);

            using(var stream = client.GetNewCustomers(new NewCustomersRequest()))
                while(await stream.ResponseStream.MoveNext())
                {
                    Console.WriteLine(stream.ResponseStream.Current);
                }

#pragma warning restore CS0436 // Type conflicts with imported type
                Console.ReadLine();
        }
    }
}
