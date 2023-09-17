using Domain.Entities;

namespace Appllication.Services.Dtos.CustomerDto
{
    public interface ICustomerMapper
    {
        ReadCustomerDto FromCustomer(Customer customer);
        Customer FromCustomerDto(ReadCustomerDto customer);
        List<ReadCustomerDto> FromCustomerList(IReadOnlyCollection<Customer> orders);
    }
}
