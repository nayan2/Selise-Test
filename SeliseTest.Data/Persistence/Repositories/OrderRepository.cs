using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<int> CreateOrder(int CustomerId)
        {
            var newOrder = new Order { CustomerId = CustomerId };
            await base.AddAsync(newOrder);
            _dbContext.SaveChanges();
            return newOrder.Id;
        }
    }
}
