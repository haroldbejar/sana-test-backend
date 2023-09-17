using Appllication.Services.Dtos.CategoryDto;
using Domain.Entities;
using Repositories;
using Repositories.CategoryRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryMapper mapper;
        private readonly IBaseRepository<Category> _repository;

        public CategoryService(ICategoryMapper mapper,
                    IBaseRepository<Category> repository)
        {
            this.mapper = mapper;
            _repository = repository;
        }

        public ICategoryRepository CategoryRepository { get; }

        #region CRUD
        public async Task<IReadOnlyCollection<ReadCategoryDto>> GetAllAsync()
        {
            var CategoryList = mapper.FromCategoryList(await _repository.GetAllAsync());
            return CategoryList;
        }

        public async Task<ReadCategoryDto> GetByIdAsync(int id)
        {
            var category = mapper.FromCategory(await _repository.GetByIdAsync(id));
            return category;
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(ReadCategoryDto _category)
        {
            var category = mapper.FromCategoryDto(_category);
            await _repository.InsertAsync(category);
        }
        public async Task UpdateAsync(ReadCategoryDto _category)
        {
            var category = mapper.FromCategoryDto(_category);
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            await _repository.DeleteByIdAsync(category.Id);

        }

        #endregion
    }
}
