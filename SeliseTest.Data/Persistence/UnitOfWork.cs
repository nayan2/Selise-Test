using SeliseTest.Data.Core;
using SeliseTest.Data.Core.Repositories;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext, 
            IUserGroupRepository userGroupRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICustomerRepository customerRepository)
        {
            this._dbContext = dbContext;
            this.UserGroups = userGroupRepository;
            this.Products = productRepository;
            this.Orders = orderRepository;
            this.OrderItems = orderItemRepository;
            this.Customers = customerRepository;
        }

       public IUserGroupRepository UserGroups { get; }
       public IProductRepository Products { get; }
       public IOrderRepository Orders { get; }
       public IOrderItemRepository OrderItems { get; }
       public ICustomerRepository Customers { get; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
