using Appllication.Services.Dtos.OrderDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.ProductDto
{
    public interface IProductMapper
    {
        ReadProductDto FromProduct(Product product);
        Product FromProductDto(ReadProductDto product);
        List<ReadProductDto> FromProductList(IReadOnlyCollection<Product> products);
    }
}
