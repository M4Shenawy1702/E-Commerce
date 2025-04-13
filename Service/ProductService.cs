using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstraction.IService;
using Shared.Dtos.Products;

namespace Service
{
    internal class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IProductService
    {
        public async Task<ProductResponseDto> GetProductAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(id);
            return _mapper.Map<ProductResponseDto>(product); ;
        }
        public async Task<IEnumerable<BrandResponseDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandResponseDto>>(brands);
        }


        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<IEnumerable<TypeResponseDto>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeResponseDto>>(Types);
        }
    }
}
