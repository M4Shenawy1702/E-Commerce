using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Attributes;
using ServiceAbstraction.IService;
using Shared;
using Shared.Dtos.BrandDtos;
using Shared.Dtos.ProductDto;
using Shared.Dtos.Products;
using Shared.Dtos.TypeDtos;

namespace Presentation.Controllers
{
    public class ProductsController(IServiceManager _serviceManager)
        : APIController
    {
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductAsync(int id)
        {
            var result = await _serviceManager.ProductService.GetProductAsync(id);
            return Ok(result);
        }
        [RedisCache]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResponseDto>>> GetAllProductsAsync([FromQuery] ProductQueryParameters parameters)
        {
            var result = await _serviceManager.ProductService.GetAllProductsAsync(parameters);
            return Ok(result);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> AddProductAsync([FromForm] ProductDto dto)
        {
                var product = await _serviceManager.ProductService.AddProductAsync(dto);
                return Ok(product);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDto>> UpdateProductAsync(int id, [FromBody] ProductDto dto)
        {
                var product = await _serviceManager.ProductService.UpdateProductAsync(id, dto);
                return Ok(product);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductAsync(int id)
        {

            var result = await _serviceManager.ProductService.DeleteProductAsync(id);
            return Ok(result);
        }
    }
}
