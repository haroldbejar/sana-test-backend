using Appllication.Services.Dtos.CustomerDto;
using Domain.Entities;
using Repositories;

namespace Appllication.Services.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerMapper mapper;
        private readonly IBaseRepository<Customer> _repository;
        public CustomerService(ICustomerMapper mapper,
                              IBaseRepository<Customer> repository)
        {
            this.mapper = mapper;
            this._repository = repository;
        }


        #region CRUD
        public async Task DeleteByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            await _repository.DeleteByIdAsync(customer.Id);
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<ReadCustomerDto>> GetAllAsync()
        {
            var CustomerList = mapper.FromCustomerList(await _repository.GetAllAsync());
            return CustomerList;
        }

        public async Task<ReadCustomerDto> GetByIdAsync(int id)
        {
            var customer = mapper.FromCustomer(await _repository.GetByIdAsync(id));
            return customer;
        }

        public async Task InsertAsync(ReadCustomerDto _customer)
        {
            var customer = mapper.FromCustomerDto(_customer);
            await _repository.InsertAsync(customer);
        }

        public async Task UpdateAsync(ReadCustomerDto _customer)
        {
            var customer = mapper.FromCustomerDto(_customer);
            await _repository.UpdateAsync(customer);
        }

        #endregion
    }
}
