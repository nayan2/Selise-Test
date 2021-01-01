using SeliseTest.Data.Core.Domain;
using SeliseTest.Data.Core.Repositories;
using SeliseTest.Data.Core.Services;
using SeliseTest.Data.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserGroupRepository _userGroupRepository;
        public CustomerService(ICustomerRepository customerRepository, IUserGroupRepository userGroupRepository)
        {
            _customerRepository = customerRepository;
            _userGroupRepository = userGroupRepository;
        }

        public async Task<Customer> Add(string email, string name, int groupId)
        {
            try
            {
                var oldUser = await _customerRepository.FirstOrDefaultAsync(x => x.Email == email);
                if (oldUser != null)
                    throw new ApplicationException("User already exist");

                var cus = new Customer
                {
                    Email = email,
                    Name = name,
                    UserGroupId = groupId
                };

                await _customerRepository.AddAsync(cus);
                return cus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object> PaymentDetails(int customerId, int orderId)
        {
            try
            {
                var customer = await _customerRepository.FirstOrDefaultAsync(
                        x => x.Id == customerId,
                        x => x.Orders.Where(x => x.Id == orderId).Select(x => x.OrderItems.Select(x => x.Product)),
                        X => X.UserGroup);

                if (customer == null)
                    throw new ApplicationException("Invalid order details requested");

                var totalAmount = customer.Orders.SelectMany(x => x.OrderItems.Select(x => x.Product.Price)).Sum();
                var totalAmountAfterDiscount = totalAmount - ((totalAmount * customer.UserGroup.Discount) / 100);

                return new { order = customer.Orders, OriginalPrice = totalAmount, DiscountPrice = totalAmountAfterDiscount };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            try
            {
                return await _customerRepository.FirstOrDefaultAsync(x => x.Email == email);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
