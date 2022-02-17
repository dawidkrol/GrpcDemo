using System.Collections.Generic;
using System.Threading;

namespace GrpcServer.Helpers
{
    public class CustomersData : ICustomersData
    {
        public IEnumerable<CustomerInfo> GetCustomers()
        {
            List<CustomerInfo> customers = new List<CustomerInfo>()
            {
                new CustomerInfo()
                {
                    FirstName = "Dawid",
                    LastName = "Król",
                    Email = "dawidkrol7@gmail.com",
                    IsAlive = true,
                    Age = 20
                },
                new CustomerInfo()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "jognsmith@gmail.com",
                    IsAlive = false,
                    Age = 99
                },
                new CustomerInfo()
                {
                    FirstName = "Anna",
                    LastName = "Smith",
                    Email = "annasmith@gmail.com",
                    IsAlive = true,
                    Age = 89
                }
            };

            foreach (var customer in customers)
            {
                Thread.Sleep(1000);
                yield return customer;
            }
        }
    }
}
