using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.OrderDto
{
    public interface IOrderMapper
    {
        ReadOrderDto FromOrder(Order order);
        Order FromOrderDto(ReadOrderDto order);
        List<ReadOrderDto> FromOrderList(IReadOnlyCollection<Order> orders);
    }
}
