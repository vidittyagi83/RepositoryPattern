using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Interfaces;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        public ProductController(IProductRepository repository, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var service = _serviceProvider.GetRequiredService<IProductRepository>();
            var result = await _repository.GetAllAsync();


            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(new { Error = result.ErrorMessage });
        }
    }
}
