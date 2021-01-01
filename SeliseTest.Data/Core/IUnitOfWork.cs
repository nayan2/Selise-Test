using SeliseTest.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Core
{
    public interface IUnitOfWork
    {
        IUserGroupRepository UserGroups { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        ICustomerRepository Customers { get; }
        int Complete();
    }
}
