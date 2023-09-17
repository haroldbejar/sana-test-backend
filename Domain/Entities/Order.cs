using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public  Decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Delivery { get; set; }
        public List<OrderDetails> Details { get; set; }

    }
}
