using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.ProductRepo
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        

        #region specific methods

        public async Task<IReadOnlyCollection<Product>> SearchProducts(string search)
        {
            var product = await _context.Products
                     .Where(p => p.Name.Contains(search))
                     .ToListAsync();

            return product;
        }

        #endregion
    }
}
