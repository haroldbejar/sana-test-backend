using Domain.Entities;

namespace Appllication.Services.Dtos.CategoryDto
{
    public class CategoryMapper : ICategoryMapper
    {
        public ReadCategoryDto FromCategory(Category category)
        {
            return new ReadCategoryDto { Code = category.Code, Name = category.Name, };
        }

        public List<ReadCategoryDto> FromCategoryList(IReadOnlyCollection<Category> categories)
        {
            var categoriesList = new List<ReadCategoryDto>();

            foreach (var category in categories)
            {
                var categoryDto = new ReadCategoryDto { Id = category.Id, Code = category.Code, Name = category.Name, };
                categoriesList.Add(categoryDto);
            }

            return categoriesList;
        }

        public Category FromCategoryDto(ReadCategoryDto category) 
        {
            return new Category { Id = category.Id, Code = category.Code, Name = category.Name, };
        }
    }
}
