using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeliseTest.Data.Core;
using SeliseTest.Data.Core.Domain.DTO;
using SeliseTest.Data.Core.Services;

namespace SeliseTest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                await _customerService.Add(customer.Email, customer.Name, customer.UserGroupId);
                _unitOfWork.Complete();
                var createdCustomer = await _customerService.GetCustomerByEmail(customer.Email);
                if(createdCustomer == null)
                    throw new ApplicationException("Try again after some time! unknown error");

                return Created($"/api/Customer/{createdCustomer.Id}", createdCustomer);
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Internal server error!");
            }
        }

        [HttpGet("{customerId}/{orderId}")]
        public async Task<IActionResult> GetPaymentDetails(int customerId, int orderId)
        {
            try
            {
                return Ok(await _customerService.PaymentDetails(customerId, orderId));
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error!");
            }
        }
    }
}
