using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<int> TagOrderWithItem(int orderId, int customerId)
        {
            try
            {
                var orderItems = await base.GetAllAsync(x => x.CustomerId == customerId && !x.Completed && x.CreatedAt.Date == DateTime.Now.Date);
                orderItems.ToList().ForEach(x =>
                {
                    x.OrderId = orderId;
                });
                await base.EditAsync(orderItems);
                _dbContext.SaveChanges();
                return orderId;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
