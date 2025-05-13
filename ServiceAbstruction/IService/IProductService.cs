using Shared;
using Shared.Dtos.BrandDtos;
using Shared.Dtos.ProductDto;
using Shared.Dtos.Products;
using Shared.Dtos.TypeDtos;

namespace ServiceAbstraction.IService
{
    public interface IProductService
    {
        Task<ProductResponseDto> GetProductAsync(int id);
        Task<PaginatedResult<ProductResponseDto>> GetAllProductsAsync(ProductQueryParameters parameters);
        Task<ProductResponseDto> AddProductAsync(ProductDto dto);
        Task<ProductResponseDto> UpdateProductAsync(int id, ProductDto dto);
        Task<bool> DeleteProductAsync(int id);

    }
}
