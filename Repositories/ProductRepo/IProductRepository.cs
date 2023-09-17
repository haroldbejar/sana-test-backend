using Domain.Entities;

namespace Repositories.ProductRepo
{
    public interface IProductRepository
    {
        Task<IReadOnlyCollection<Product>> SearchProducts(string search);
    }
}
