using Appllication.Services.Dtos.CategoryDto;
using Appllication.Services.Dtos.OrderDto;
using Appllication.Services.Services.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/order")]
    
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var results = await _orderService.GetAllAsync();
            if (results == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _orderService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ReadOrderDto order)
        {
            await _orderService.InsertAsync(order);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(ReadOrderDto order, int id)
        {
            var existingOrder = await _orderService.GetByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.Total = order.Total;
            existingOrder.Description = order.Description;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.Delivery = order.Delivery;


            await _orderService.UpdateAsync(existingOrder);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _orderService.FindByIdAsync(id);
            if (exist == null)
            {
                return NotFound();
            }

            await _orderService.DeleteByIdAsync(id);
            return Ok();
        }

        #endregion

    }
}
