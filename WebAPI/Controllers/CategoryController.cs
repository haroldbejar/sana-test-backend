using Appllication.Services.Dtos.CategoryDto;
using Appllication.Services.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Operators;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var results = await _categoryService.GetAllAsync();
            if (results == null) 
            {
                return BadRequest("There isn't data...");
            }

            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest("There isn't data...");
            }

            return Ok(result);
        }
        
        [HttpPost] 
        public async Task<ActionResult> Insert(ReadCategoryDto category) 
        {
            await _categoryService.InsertAsync(category);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(ReadCategoryDto category, int id)
        {
            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Code = category.Code;
            existingCategory.Name = category.Name;

            await _categoryService.UpdateAsync(existingCategory);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _categoryService.FindByIdAsync(id);
            if (exist == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteByIdAsync(id);
            return Ok();
        }

        #endregion
    }
}
