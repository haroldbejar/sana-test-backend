using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Dtos.ProductDto
{
    public class ProductMapper : IProductMapper
    {
        public ReadProductDto FromProduct(Product product)
        {
            return new ReadProductDto
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UrlImage = product.UrlImage,
            };
        }

        public Product FromProductDto(ReadProductDto product)
        {
            return new Product
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UrlImage = product.UrlImage,
            };
        }

        public List<ReadProductDto> FromProductList(IReadOnlyCollection<Product> products)
        {
            var productList = new List<ReadProductDto>();

            foreach (var product in products)
            {
                var productDto = new ReadProductDto
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    UrlImage = product.UrlImage,
                };
                productList.Add(productDto);
            }

            return productList;
        }
    }
}
