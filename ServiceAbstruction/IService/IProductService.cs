using Shared.Dtos.Products;

namespace ServiceAbstraction.IService
{
    public interface IProductService
    {
        Task<ProductResponseDto> GetProductAsync(int id);
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<IEnumerable<BrandResponseDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeResponseDto>> GetAllTypesAsync();

    }
}
