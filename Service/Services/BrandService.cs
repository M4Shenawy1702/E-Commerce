using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Product;
using Service.BaseSpecifications;
using ServiceAbstraction.IService;
using Shared.Dtos.BrandDtos;

namespace Service.Services
{
    public class BrandService(IUnitOfWork _unitOfWork, IMapper _mapper) : IBrandService
    {
        public async Task<IEnumerable<BrandResponseDto>> GetAllAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync(false);
            return _mapper.Map<IEnumerable<BrandResponseDto>>(brands);
        }

        public async Task<BrandResponseDto?> GetByIdAsync(int id)
        {
            var brand = await _unitOfWork.GetRepository<ProductBrand, int>().GetAsync(id);
            return _mapper.Map<BrandResponseDto>(brand);
        }

        public async Task<BrandResponseDto> AddAsync(BrandDto dto)
        {
            var specifications = new GetBrandByNameSpecification(dto.Name);
            if (await _unitOfWork.GetRepository<ProductBrand, int>().GetAsync(specifications) != null)
                throw new BrandWithNameExistException(dto.Name);

            var brand = _mapper.Map<ProductBrand>(dto);
            _unitOfWork.GetRepository<ProductBrand, int>().Add(brand);
            await _unitOfWork.SaveChangesAsync(); 
            return _mapper.Map<BrandResponseDto>(brand);
        }

        public async Task<BrandResponseDto> UpdateAsync(int id, BrandDto dto)
        {
            var existingBrand = await _unitOfWork.GetRepository<ProductBrand, int>().GetAsync(id)??
                throw new BrandNotFoundException(id);

            existingBrand.Name = dto.Name;

            _unitOfWork.GetRepository<ProductBrand, int>().Update(existingBrand);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BrandResponseDto>(existingBrand);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _unitOfWork.GetRepository<ProductBrand, int>().GetAsync(id) ??
                 throw new BrandNotFoundException(id);

            _unitOfWork.GetRepository<ProductBrand, int>().Delete(brand);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
