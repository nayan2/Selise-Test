using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Core.Services
{
    public interface ICustomerService
    {
        Task<Customer> Add(string email, string name, int groupId);
        Task<Object> PaymentDetails(int customerId, int orderId);
        Task<Customer> GetCustomerByEmail(string email);
    }
}
