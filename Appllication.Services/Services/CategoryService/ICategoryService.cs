using Appllication.Services.Dtos.CategoryDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.CategoryService
{
    public interface ICategoryService
    {
        Task DeleteByIdAsync(int id);
        Task<Category> FindByIdAsync(int id);
        Task<IReadOnlyCollection<ReadCategoryDto>> GetAllAsync();
        Task<ReadCategoryDto> GetByIdAsync(int id);
        Task InsertAsync(ReadCategoryDto _category);
        Task UpdateAsync(ReadCategoryDto _category);
    }
}
