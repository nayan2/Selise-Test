using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeliseTest.Data.Core;
using SeliseTest.Data.Core.Services;

namespace SeliseTest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderController(IUnitOfWork unitOfWork, IOrderService orderService, IOrderItemService orderItemService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        [HttpGet("{productId}/{customerId}")]
        public async Task<IActionResult> AddItemToCurrentOrder(int productId, int customerId)
        {
            try
            {
                var item = await _orderItemService.AddItem(productId, customerId);
                _unitOfWork.Complete();
                return Ok(item);
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

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult> RemoveItemFromCurrentOrder(int orderItemId)
        {
            try
            {
                return Ok(await _orderItemService.RemoveItem(orderItemId));
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
