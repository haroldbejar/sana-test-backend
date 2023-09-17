using Appllication.Services.Dtos.CategoryDto;
using Appllication.Services.Dtos.OrderDto;
using Domain.Entities;
using Repositories;
using Repositories.OrderRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderMapper mapper;
        private readonly IBaseRepository<Order> _repository;

        public OrderService(IOrderMapper mapper,
                            IBaseRepository<Order> repository)
        {
            this.mapper = mapper;
            this._repository = repository;
        }

        public IOrderRepository OrderRepository { get; }

        #region CRUD
        public async Task DeleteByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            await _repository.DeleteByIdAsync(order.Id);
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<ReadOrderDto>> GetAllAsync()
        {
            var OrderList = mapper.FromOrderList(await _repository.GetAllAsync());
            return OrderList;
        }

        public async Task<ReadOrderDto> GetByIdAsync(int id)
        {
            var order = mapper.FromOrder(await _repository.GetByIdAsync(id));
            return order;
        }

        public async Task InsertAsync(ReadOrderDto _order)
        {
            var order = mapper.FromOrderDto(_order);
            await _repository.InsertAsync(order);
        }

        public async Task UpdateAsync(ReadOrderDto _order)
        {
            var order = mapper.FromOrderDto(_order);
            await _repository.UpdateAsync(order);
        }

        #endregion
    }
}