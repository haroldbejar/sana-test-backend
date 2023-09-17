using Appllication.Services.Dtos.CategoryDto;
using Appllication.Services.Dtos.OrderDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.OrderService
{
    public interface IOrderService
    {
        Task DeleteByIdAsync(int id);
        Task<Order> FindByIdAsync(int id);
        Task<IReadOnlyCollection<ReadOrderDto>> GetAllAsync();
        Task<ReadOrderDto> GetByIdAsync(int id);
        Task InsertAsync(ReadOrderDto _order);
        Task UpdateAsync(ReadOrderDto _order);
    }
}
