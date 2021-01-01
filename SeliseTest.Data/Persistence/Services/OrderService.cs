using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using SeliseTest.Data.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        private async Task<int> CreateOrder(int CustomerId)
        {
            try
            {
                var order = await _orderRepository.FirstOrDefaultAsync(x => !x.IsCompletd
                                        && x.CreatedAt.Date == DateTime.Now.Date);
                if(order == null)
                {
                    return await _orderRepository.CreateOrder(CustomerId);
                }
                return order.Id;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Order> OrderDetails(int CustomerId)
        {
            try
            {
                var orderId = await this.CreateOrder(CustomerId);
                await _orderItemRepository.TagOrderWithItem(orderId, CustomerId);
                var order = await _orderRepository.FirstOrDefaultAsync(x => x.CustomerId == CustomerId,
                    includes: x => x.OrderItems);
                if (order == null)
                    throw new ApplicationException("No order found of the user");
                return order;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
