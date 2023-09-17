using Appllication.Services.Dtos.ProductDto;
using Domain.Entities;
using Repositories;
using Repositories.ProductRepo;

namespace Appllication.Services.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductMapper mapper;
        private readonly IBaseRepository<Product> _repository;
        private readonly IProductRepository _productRepository;
        public ProductService(IProductMapper mapper, 
                              IBaseRepository<Product> repository,
                              IProductRepository productRepository) 
        {
            this.mapper = mapper;
            this._repository = repository;
            this._productRepository = productRepository;
        }

        #region CRUD
        public async Task DeleteByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            await _repository.DeleteByIdAsync(product.Id);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<ReadProductDto>> GetAllAsync()
        {
            var ProductList = mapper.FromProductList(await _repository.GetAllAsync());
            return ProductList;
        }

        public async Task<ReadProductDto> GetByIdAsync(int id)
        {
            var product = mapper.FromProduct(await _repository.GetByIdAsync(id));
            return product;
        }

        public async Task InsertAsync(ReadProductDto _product)
        {
            var product = mapper.FromProductDto(_product);
            await _repository.InsertAsync(product);
        }

        public async Task UpdateAsync(ReadProductDto _product)
        {
            var product = mapper.FromProductDto(_product);
            await _repository.UpdateAsync(product);
        }

        #endregion

        #region specific methods

        public async Task<IReadOnlyCollection<Product>> SearchProducts(string search)
        {
            var result = await _productRepository.SearchProducts(search);
            return result;
        }

        #endregion
    }
}
