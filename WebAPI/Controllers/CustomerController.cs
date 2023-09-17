using Appllication.Services.Dtos.CategoryDto;
using Appllication.Services.Dtos.CustomerDto;
using Appllication.Services.Services.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _custormerService;

        public CustomerController(ICustomerService custormerService)
        {
            this._custormerService = custormerService;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var results = await _custormerService.GetAllAsync();
            if (results == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _custormerService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ReadCustomerDto customer)
        {
            await _custormerService.InsertAsync(customer);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(ReadCustomerDto customer, int id)
        {
            var existingCustomer = await _custormerService.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.Id = customer.Id;
            existingCustomer.Name = customer.Name;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.DocumentID = customer.DocumentID;
            existingCustomer.Adress = customer.Adress;

            await _custormerService.UpdateAsync(existingCustomer);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _custormerService.FindByIdAsync(id);
            if (exist == null)
            {
                return NotFound();
            }

            await _custormerService.DeleteByIdAsync(id);
            return Ok();
        }

        #endregion
    }
}
