using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using SeliseTest.Data.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SeliseTest.Data.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetItems()
        {
            try
            {
                var result = await _productRepository.GetAllAsync();
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
