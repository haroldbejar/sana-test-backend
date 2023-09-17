using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.OrderDto
{
    public class ReadOrderDto
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public Decimal Total { get; set; }
        public  DateTime OrderDate { get; set; }
        public DateTime Delivery { get; set; }
        public List<OrderDetails> Details { get; set; }
    }
}
