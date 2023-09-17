using Appllication.Services.Dtos.ProductDto;
using Appllication.Services.Services.CategoryService;
using Appllication.Services.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        

        public ProductController(IProductService productService, 
                                ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var results = await _productService.GetAllAsync();
            if (results == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ReadProductDto product)
        {   
            await _productService.InsertAsync(product);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(ReadProductDto product, int id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Id = product.Id;
            existingProduct.Code = product.Code;
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.UrlImage = product.UrlImage;

            await _productService.UpdateAsync(existingProduct);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _productService.FindByIdAsync(id);
            if (exist == null)
            {
                return NotFound();
            }

            await _productService.DeleteByIdAsync(id);
            return Ok();
        }

        #endregion

        #region specific endpoints

        [HttpGet("search")]
        public async Task<ActionResult> SearchProducts(string search)
        {
            var result = await _productService.SearchProducts(search);
            return Ok(result);
        }

        #endregion
    }
}
