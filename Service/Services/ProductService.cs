using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Product;
using Service.BaseSpecifications;
using Service.Specifications;
using ServiceAbstraction.IService;
using Shared;
using Shared.Dtos.BrandDtos;
using Shared.Dtos.ProductDto;
using Shared.Dtos.Products;
using Shared.Dtos.TypeDtos;

namespace Service.Services
{
    internal class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IProductService
    {
        private long _maxPictureSize = 1 * 1024 * 1024;
        private string[] _allowedExtensions = { ".jpg", ".png", ".jpeg" };
        public async Task<ProductResponseDto> GetProductAsync(int id)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(specifications)
                ?? throw new ProductNotFoundException(id);
            return _mapper.Map<ProductResponseDto>(product); ;
        }

        public async Task<PaginatedResult<ProductResponseDto>> GetAllProductsAsync(ProductQueryParameters parameters)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(parameters);
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
            var data = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
            var pageCount = data.Count();
            var totalCount = await _unitOfWork.GetRepository<Product, int>().GetCountAsync(new ProductsCountSpecifications(parameters));
            return new(parameters.PageIndex, pageCount, totalCount, data);
        }

        public async Task<ProductResponseDto> AddProductAsync(ProductDto dto)
        {
            var repository = _unitOfWork.GetRepository<Product, int>();

            var specifications = new GetProductByNameSpecification(dto.Name);
            var existingProduct = await repository.GetAsync(specifications);
            if (existingProduct != null)
                throw new ProductWithNameExistException(dto.Name);
            

            var extension = Path.GetExtension(dto.Picture.FileName);
            if (!_allowedExtensions.Contains(extension.ToLower()))
                throw new InvalidPictureFormatException();

            if (dto.Picture.Length > _maxPictureSize)
                throw new InvalidPictureSizeException();

            var sanitizedFileName = $"{dto.Name.Trim().Replace(" ", "")}{extension}";
            var imagePath = Path.Combine("wwwroot/images/products", sanitizedFileName);
            var relativeImagePath = $"/images/products/{sanitizedFileName}";

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await dto.Picture.CopyToAsync(stream);
            }

            var product = _mapper.Map<Product>(dto);
            product.PictureUrl = relativeImagePath;

            repository.Add(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductResponseDto>(product);
        }


        public async Task<ProductResponseDto> UpdateProductAsync(int id, ProductDto dto)
        {
            var repository = _unitOfWork.GetRepository<Product, int>();

            var existingProductWithSameName = await repository.GetAsync(new GetProductByNameSpecification(dto.Name));
            if (existingProductWithSameName != null && existingProductWithSameName.Id != id)
            {
                throw new ProductWithNameExistException(dto.Name);
            }

            var product = await repository.GetAsync(id)
                ?? throw new ProductNotFoundException(id);

            var extension = Path.GetExtension(dto.Picture.FileName);

            if (!_allowedExtensions.Contains(extension.ToLower()))
                throw new InvalidPictureFormatException();

            if (dto.Picture.Length > _maxPictureSize)
                throw new InvalidPictureSizeException();

            var sanitizedFileName = $"{dto.Name.Trim().Replace(" ", "")}{extension}";
            var imagePath = Path.Combine("wwwroot/images/products", sanitizedFileName);
            var relativeImagePath = $"/images/users/{sanitizedFileName}";


            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await dto.Picture.CopyToAsync(stream);
            }


            product.Name = dto.Name;
            product.Description = dto.Description;
            product.PictureUrl = relativeImagePath;
            product.Price = dto.Price;
            product.BrandId = dto.BrandId;
            product.TypeId = dto.TypeId;

            repository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Product, int>();

            var product = await repository.GetAsync(id)
                ?? throw new ProductNotFoundException(id);

            repository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
