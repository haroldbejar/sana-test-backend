using Domain.Data;
using Domain.Entities;

namespace Repositories.CategoryRepo
{
    public class CategoryRepository :  BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
