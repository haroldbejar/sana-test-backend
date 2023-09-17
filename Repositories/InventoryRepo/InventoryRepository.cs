using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.ViewModels;
using NPOI.SS.Formula.Functions;
using NPOI.OpenXmlFormats.Wordprocessing;

namespace Repositories.InventoryRepo
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext _context) : base(_context)
        {
            this._context = _context;
        }

        #region specific methods
        public async Task<IReadOnlyList<Inventory>> GetByCategoryId(int categoryId)
        {
            return await _context.Inventories.Where(i => i.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductViewModel>> GetAllAsyncRelated()
        {
            var products = await (from inventory in _context.Inventories
                                  join product in _context.Products on inventory.ProductId equals product.Id
                                  join category in _context.Categories on inventory.CategoryId equals category.Id
                                  select new ProductViewModel
                                  {
                                     ProductId = product.Id,
                                     InventoryId = inventory.Id,
                                     CategoryId = category.Id,
                                     Quantity = inventory.Quantity,
                                     Code = product.Code, 
                                     ProductName = product.Name, 
                                     CategoryName = category.Name,
                                     Price = product.Price,
                                     Description = product.Description,
                                     UrlImage = product.UrlImage
                                   }).ToListAsync();

            return  products;
        }

        public async Task<IReadOnlyList<ProductViewModel>> GetProductsByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            var products = await (from inventory in _context.Inventories
                                  join product in _context.Products on inventory.ProductId equals product.Id
                                  join category in _context.Categories on inventory.CategoryId equals category.Id
                                  where category.Id == categoryId 
                                  select new ProductViewModel
                                  {
                                      ProductId = product.Id,
                                      InventoryId = inventory.Id,
                                      CategoryId = category.Id,
                                      Quantity = inventory.Quantity,
                                      Code = product.Code,
                                      ProductName = product.Name,
                                      CategoryName = category.Name,
                                      Price = product.Price,
                                      Description = product.Description,
                                      UrlImage = product.UrlImage
                                  })
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return products;
        }

        #endregion
    }
}
