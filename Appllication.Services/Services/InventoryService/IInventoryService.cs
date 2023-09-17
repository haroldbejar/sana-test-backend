using Appllication.Services.Dtos.InventoryDto;
using Appllication.Services.Dtos.ProductDto;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.InventoryService
{
    public interface IInventoryService
    {
        Task DeleteByIdAsync(int id);
        Task<Inventory> FindByIdAsync(int id);
        Task<IReadOnlyCollection<ProductViewModel>> GetAllAsync();
        Task<ReadInventoryDto> GetByIdAsync(int id);
        Task InsertAsync(ReadInventoryDto _inventory);
        Task UpdateAsync(ReadInventoryDto _inventory);
        Task<IReadOnlyList<ReadInventoryDto>> GetByCategoryId(int categoryId);
        Task<IReadOnlyList<ReadInventoryDto>> PaginatedItems(int pageNumber, int pageSize);
        Task<int> Count();
        Task<IReadOnlyList<ProductViewModel>> GetProductsByCategoryIdAsync(int categoryId, int pageNumber, int pageSize);
    }
}
