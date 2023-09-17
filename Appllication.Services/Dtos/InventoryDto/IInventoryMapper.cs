using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.InventoryDto
{
    public interface IInventoryMapper
    {
        ReadInventoryDto FromInventory(Inventory inventory);
        Inventory FromInventoryDto(ReadInventoryDto inventory);
        List<ReadInventoryDto> FromInventoryList(IReadOnlyList<Inventory> inventories);
    }
}
