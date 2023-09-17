using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.InventoryDto
{
    public class InventoryMapper : IInventoryMapper
    {
        public ReadInventoryDto FromInventory(Inventory inventory)
        {
            return new ReadInventoryDto
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                Code = inventory.Code,
                Name = inventory.Name,
                Price = inventory.Price,
                UrlImage = inventory.UrlImage,
                CategoryId = inventory.CategoryId,
                Quantity = inventory.Quantity,
                TotalPrice = inventory.TotalPrice,
            };
        }

        public Inventory FromInventoryDto(ReadInventoryDto inventory)
        {
            return new Inventory
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                Code = inventory.Code,
                Name = inventory.Name,
                Price = inventory.Price,
                UrlImage = inventory.UrlImage,
                CategoryId = inventory.CategoryId,
                Quantity = inventory.Quantity,
                TotalPrice = inventory.TotalPrice,
            };
        }

        public List<ReadInventoryDto> FromInventoryList(IReadOnlyList<Inventory> inventories) 
        {
            var inventoryList = new List<ReadInventoryDto>();

            foreach (var inventory in inventories) 
            {
                var inventoryDto = new ReadInventoryDto
                {
                    Id = inventory.Id,
                    ProductId = inventory.ProductId,
                    Code = inventory.Code,
                    Name = inventory.Name,
                    Price = inventory.Price,
                    UrlImage = inventory.UrlImage,
                    CategoryId = inventory.CategoryId,
                    Quantity = inventory.Quantity,
                    TotalPrice = inventory.TotalPrice,
                };
                inventoryList.Add(inventoryDto);
            }

            return inventoryList;
        }
        
    }
}
