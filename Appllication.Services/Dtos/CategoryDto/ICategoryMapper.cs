using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.CategoryDto
{
    public interface ICategoryMapper
    {
        ReadCategoryDto FromCategory(Category category);

        List<ReadCategoryDto> FromCategoryList(IReadOnlyCollection<Category> categories);

        Category FromCategoryDto(ReadCategoryDto category);
    }
}
