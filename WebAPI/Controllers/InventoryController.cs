using Appllication.Services.Dtos.InventoryDto;
using Appllication.Services.Dtos.ProductDto;
using Appllication.Services.Services.CategoryService;
using Appllication.Services.Services.InventoryService;
using Appllication.Services.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public InventoryController(IInventoryService inventoryService, 
                                    ICategoryService categoryService,
                                    IProductService productService)
        {
            this._inventoryService = inventoryService;
            this._categoryService = categoryService;
            this._productService = productService;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var results = await _inventoryService.GetAllAsync();
            if (results == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _inventoryService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ReadInventoryDto inventory)
        {
            var existingCategory = await _categoryService.FindByIdAsync(inventory.CategoryId);
            if (existingCategory == null)
            {
                return BadRequest("The category doesn't exist...");
            }

            var existingProduct = await _productService.FindByIdAsync(inventory.ProductId);
            if (existingProduct == null)
            {
                return BadRequest("The product doesn't exist...");
            }

            await _inventoryService.InsertAsync(inventory);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(ReadInventoryDto inventory, int id)
        {
            var existingInventory = await _inventoryService.GetByIdAsync(id);
            if (existingInventory == null)
            {
                return NotFound();
            }
            existingInventory.Id = inventory.Id;
            existingInventory.ProductId = inventory.ProductId;
            existingInventory.CategoryId = inventory.CategoryId;
            existingInventory.Quantity = inventory.Quantity;
            existingInventory.TotalPrice = inventory.TotalPrice;
            

            await _inventoryService.UpdateAsync(existingInventory);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _inventoryService.FindByIdAsync(id);
            if (exist == null)
            {
                return NotFound();
            }

            await _inventoryService.DeleteByIdAsync(id);
            return Ok();
        }

        #endregion

        #region specific endpoints

        [HttpGet("category/{categoryId:int}")]
        public async Task<ActionResult> GetByCategoryId(int categoryId)
        {
            var result = await _inventoryService.GetByCategoryId(categoryId);
            if (result == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(result);
        }

        [HttpGet("page/{pageNumber:int}/{pageSize:int}")]
        public async Task<ActionResult> GetPaginatedInventory(int pageNumber, int pageSize)
        {
            var totalItems = await _inventoryService.Count();
            var inventory = await _inventoryService.PaginatedItems(pageNumber, pageSize);

            var paginationData = new
            {
                totalCount = totalItems,
                pageSize,
                currentPage = pageNumber,
                totalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            };

            return Ok(new {inventory, paginationData });
        }

        [HttpGet("category/{categoryId:int}/{pageNumber:int}/{pageSize:int}")]
        public async Task<ActionResult> GetPruductsByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            var totalItems = await _inventoryService.Count();
            var inventory = await _inventoryService.GetProductsByCategoryIdAsync(categoryId, pageNumber, pageSize);

            var paginationData = new
            {
                totalCount = totalItems,
                pageSize,
                currentPage = pageNumber,
                totalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            };

            return Ok(new { inventory, paginationData });
        }

        #endregion
    }
}
