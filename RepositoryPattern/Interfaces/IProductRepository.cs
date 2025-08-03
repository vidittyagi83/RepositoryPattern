using RepositoryPattern.Models;

namespace RepositoryPattern.Interfaces
{
    public interface IProductRepository
    {
        Task<Result<IEnumerable<Models.Product>>> GetAllAsync();
        Task<Models.Product?> GetByIdAsync(int id);
        Task AddAsync(Models.Product product);
        Task UpdateAsync(Models.Product product);
        Task DeleteAsync(int id);
    }
}
