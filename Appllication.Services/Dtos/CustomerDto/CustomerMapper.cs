using Appllication.Services.Dtos.OrderDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.CustomerDto
{
    public class CustomerMapper : ICustomerMapper
    {
        public ReadCustomerDto FromCustomer(Customer customer)
        {
            return new ReadCustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                DocumentID = customer.DocumentID,
                Adress = customer.Adress
            };
        }

        public Customer FromCustomerDto(ReadCustomerDto customer)
        {
            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                DocumentID = customer.DocumentID,
                Adress = customer.Adress
            };
        }

        public List<ReadCustomerDto> FromCustomerList(IReadOnlyCollection<Customer> customers)
        {
            var customerList = new List<ReadCustomerDto>();

            foreach (var customer in customers)
            {
                var customerDto = new ReadCustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    LastName = customer.LastName,
                    DocumentID = customer.DocumentID,
                    Adress = customer.Adress
                };
                customerList.Add(customerDto);
            }

            return customerList;
        }
    }
}
