using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly TestContext _testContext;

        public ProductRepository(AppDbContext context, TestContext testContext)
        {
            _context = context;
            _testContext = testContext;
        }
        public async Task<Result<IEnumerable<Product>>> GetAllAsync()
        {
            try
            {
                var products = await _testContext.Products.ToListAsync();
                return Result<IEnumerable<Product>>.SuccessResult(products);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Product>>.ErrorResult($"An error occurred: {ex.Message}");
            }
        }

        //public async Task<IEnumerable<Models.Product>> GetAllAsync()
        //{
        //    // lazy loading(UseLazyLoadingProxies() should be enabled)

        //    //var productCategory = _testContext.ProductCategories.First();
        //    //var categoryName = productCategory.Category.Name; // Category is loaded automatically

        //    // early loading
        //    //var navigation = await _testContext.ProductCategories
        //    //   .Include(pc => pc.Category)
        //    //   .ToListAsync();

        //    var productCategory = await _testContext.ProductCategories.FirstAsync();

        //    // Explicitly load the related Category
        //    await _testContext.Entry(productCategory)
        //        .Reference(pc => pc.Category)
        //        .LoadAsync();

        //    // filter in early loading
        //    var productCategories = await _testContext.ProductCategories
        //                                            .Include(pc => pc.Category)
        //                                            .Where(pc => pc.Price > 100)
        //                                            .ToListAsync();

        //    var productCategories2 = await _testContext.ProductCategories
        //                                                .Include(pc => pc.Category)
        //                                                .Where(pc => pc.Category.Name == "Electronics")
        //                                                .ToListAsync();


        //    return await _testContext.Products.ToListAsync();
        //}

        public async Task<Models.Product?> GetByIdAsync(int id)
        {

            return await _testContext.Products.FindAsync(id);
        }

        public async Task AddAsync(Models.Product product)
        {
            _ = _testContext.Products.Add(product);
            _ = await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Models.Product product)
        {
            _ = _testContext.Products.Update(product);
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
