using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Core.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<int> CreateOrder(int CustomerId);
    }
}
