using System.Collections.Generic;

namespace GrpcServer.Helpers
{
    public interface ICustomersData
    {
        IEnumerable<CustomerInfo> GetCustomers();
    }
}