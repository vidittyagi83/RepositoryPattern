using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;

namespace RepositoryPattern.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<Models.Product>>> GetProductsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
