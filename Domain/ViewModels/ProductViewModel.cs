using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
    }
}
