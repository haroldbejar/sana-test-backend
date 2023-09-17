using Appllication.Services.Dtos.ProductDto;
using Domain.Entities;

namespace Appllication.Services.Services.ProductService
{
    public interface IProductService
    {
        Task DeleteByIdAsync(int id);
        Task<Product> FindByIdAsync(int id);
        Task<IReadOnlyCollection<ReadProductDto>> GetAllAsync();
        Task<ReadProductDto> GetByIdAsync(int id);
        Task InsertAsync(ReadProductDto _product);
        Task UpdateAsync(ReadProductDto _product);
        Task<IReadOnlyCollection<Product>> SearchProducts(string search);
    }
}
