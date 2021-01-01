using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Core.Services
{
    public interface IOrderService
    {
        Task<Order> OrderDetails(int CustomerId);
    }
}
