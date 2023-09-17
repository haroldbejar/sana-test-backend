using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.InventoryRepo
{
    public interface IInventoryRepository
    {
        Task<IReadOnlyList<ProductViewModel>> GetAllAsyncRelated();
        Task<IReadOnlyList<Inventory>> GetByCategoryId(int categoryId);
        Task<IReadOnlyList<ProductViewModel>> GetProductsByCategoryId(int categoryId, int pageNumber, int pageSize);
    }
}
