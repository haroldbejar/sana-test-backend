using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.OrderDto
{
    public class OrderMapper : IOrderMapper
    {
        public ReadOrderDto FromOrder(Order order)
        {
            return new ReadOrderDto { 
                CustomerId = order.CustomerId, 
                Total = order.Total,
                Description = order.Description,
                OrderDate = order.OrderDate,
                Delivery = order.Delivery,
                Details = order.Details
            };
        }

        public Order FromOrderDto(ReadOrderDto order)
        {
            return new Order
            {
                CustomerId = order.CustomerId,
                Total = order.Total,
                Description = order.Description,
                OrderDate = order.OrderDate,
                Delivery = order.Delivery,
                Details = order.Details
            };
        }

        public List<ReadOrderDto> FromOrderList(IReadOnlyCollection<Order> orders)
        {
            var orderList = new List<ReadOrderDto>();

            foreach (var order in orders)
            {
                var orderDto = new ReadOrderDto
                {

                    CustomerId = order.CustomerId,
                    Total = order.Total,
                    Description = order.Description,
                    OrderDate = order.OrderDate,
                    Delivery = order.Delivery,
                    Details = order.Details
                };
                orderList.Add(orderDto);
            }

            return orderList;
        }
    }
}
