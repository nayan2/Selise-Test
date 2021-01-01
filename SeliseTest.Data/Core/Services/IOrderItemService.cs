using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Core.Services
{
    public interface IOrderItemService
    {
        Task<OrderItem> AddItem(int productId, int customerId);
        Task<OrderItem> RemoveItem(int orderItemId);
    }
}
