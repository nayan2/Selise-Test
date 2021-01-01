using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using SeliseTest.Data.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> AddItem(int productId, int customerId)
        {
            try
            {
                var item = new OrderItem
                {
                    Completed = false,
                    CustomerId = customerId,
                    ProductId = productId
                };

                await _orderItemRepository.AddAsync(item);
                return item;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<OrderItem> RemoveItem(int orderItemId)
        {
            try
            {
                var item = await _orderItemRepository.FirstOrDefaultAsync(x => x.Id == orderItemId);
                _orderItemRepository.Remove(item);
                return item;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
