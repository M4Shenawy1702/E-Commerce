using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.IService;
using Shared.Dtos.Products;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IServiceManager _serviceManager)
        : ControllerBase
    {
        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductAsync(int id)
        {
            var result = await _serviceManager.ProductService.GetProductAsync(id);
            return Ok(result);
        }
        [HttpGet("get-all-products")]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProductsAsync()
        {
            var result = await _serviceManager.ProductService.GetAllProductsAsync();
            return Ok(result);
        }
        [HttpGet("get-all-brands")]
        public async Task<ActionResult<IEnumerable<BrandResponseDto>>> GetAllBrandsAsync()
        {
            var result = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(result);
        }
        [HttpGet("get-all-Types")]
        public async Task<ActionResult<IEnumerable<TypeResponseDto>>> GetAllTypesAsync()
        {
            var result = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(result);
        }
    }
}
