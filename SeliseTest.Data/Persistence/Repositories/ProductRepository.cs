using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
