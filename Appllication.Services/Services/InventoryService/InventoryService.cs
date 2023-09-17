using Appllication.Services.Dtos.InventoryDto;
using Domain.Entities;
using Domain.ViewModels;
using NPOI.SS.Formula.Functions;
using Repositories;
using Repositories.InventoryRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryMapper mapper;
        private readonly IBaseRepository<Inventory> _repository;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryMapper mapper, 
                                IBaseRepository<Inventory> repository,
                                IInventoryRepository inventoryRepository)
        {
            this.mapper = mapper;
            this._repository = repository;
            this._inventoryRepository = inventoryRepository;
        }

        #region CRUD
        public async Task DeleteByIdAsync(int id)
        {
            var inventory = await _repository.GetByIdAsync(id);
            await _repository.DeleteByIdAsync(inventory.Id);
        }

        public async Task<Inventory> FindByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<ProductViewModel>> GetAllAsync()
        {
            var inventoryList = await _inventoryRepository.GetAllAsyncRelated();
            return inventoryList;
        }

        public async Task UpdateAsync(ReadInventoryDto _inventory)
        {
            var inventory = mapper.FromInventoryDto(_inventory);
            await _repository.UpdateAsync(inventory);
        }
        public async Task<ReadInventoryDto> GetByIdAsync(int id)
        {
            var inventory = mapper.FromInventory(await _repository.GetByIdAsync(id));
            return inventory;
        }

        public async Task InsertAsync(ReadInventoryDto _inventory)
        {
            var inventory = mapper.FromInventoryDto(_inventory);
            await _repository.InsertAsync(inventory);
        }

        #endregion

        #region specific methods
        public async Task<IReadOnlyList<ReadInventoryDto>> GetByCategoryId(int categoryId)
        {
            var inventoryList = mapper.FromInventoryList(await _inventoryRepository.GetByCategoryId(categoryId));
            return inventoryList;
        }

        public async Task<IReadOnlyList<ReadInventoryDto>> PaginatedItems(int pageNumber, int pageSize)
        {
            return mapper.FromInventoryList(await _repository.PaginatedItems(pageNumber, pageSize));
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }

        public async Task<IReadOnlyList<ProductViewModel>> GetProductsByCategoryIdAsync(int categoryId, int pageNumber, int pageSize)
        {
            return await _inventoryRepository.GetProductsByCategoryId(categoryId, pageNumber, pageSize);
        }

        #endregion
    }
}
