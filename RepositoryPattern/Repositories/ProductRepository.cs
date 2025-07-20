using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Entities;
using RepositoryPattern.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            //return await _context.Products.ToListAsync();
            var navigation = await _context.ProductCategories
               .Include(pc => pc.Category)
               .ToListAsync();
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            _ = _context.Products.Add(product);
            _ = await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _ = _context.Products.Update(product);
            _ = await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _ = _context.Products.Remove(product);
                _ = await _context.SaveChangesAsync();
            }
        }
    }
}
