using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string UrlImage { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
