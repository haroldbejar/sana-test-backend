using Appllication.Services.Dtos.CustomerDto;
using Appllication.Services.Dtos.ProductDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.CustomerService
{
    public interface ICustomerService
    {
        Task DeleteByIdAsync(int id);
        Task<Customer> FindByIdAsync(int id);
        Task<IReadOnlyCollection<ReadCustomerDto>> GetAllAsync();
        Task<ReadCustomerDto> GetByIdAsync(int id);
        Task InsertAsync(ReadCustomerDto _customer);
        Task UpdateAsync(ReadCustomerDto _customer);
    }
}
