using Grpc.Core;
using GrpcServer.Helpers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;
        private readonly ICustomersData _data;

        public CustomersService(ILogger<CustomersService> logger, ICustomersData data)
        {
            _logger = logger;
            _data = data;
        }

        public override Task<CustomerInfo> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerInfo output = new CustomerInfo();
            switch (request.CustomerId)
            {
                case 0:
                    output.FirstName = "Dawid";
                    output.LastName = "Król";
                    output.Email = "dawidkrol7@gmail.com";
                    output.IsAlive = true;
                    output.Age = 20;
                    break;
                case 1:
                    output.FirstName = "John";
                    output.LastName = "Smith";
                    output.Email = "jognsmith@gmail.com";
                    output.IsAlive = false;
                    output.Age = 99;
                    break;
                default:
                    break;
            }

            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(NewCustomersRequest request,
            IServerStreamWriter<CustomerInfo> responseStream,
            ServerCallContext context)
        {

            foreach (var customer in _data.GetCustomers())
            {
                await responseStream.WriteAsync(customer);
            }

        }
    }
}
