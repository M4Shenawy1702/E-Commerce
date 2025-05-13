using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Product;
using Service.BaseSpecifications;
using ServiceAbstraction.IService;
using Shared.Dtos.TypeDtos;

namespace Service.Services
{
    public class TypeService(IUnitOfWork _unitOfWork, IMapper _mapper) : ITypeService
    {
        public async Task<IEnumerable<TypeResponseDto>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync(false);
            return _mapper.Map<IEnumerable<TypeResponseDto>>(Types);
        }

        public async Task<TypeResponseDto?> GetByIdAsync(int id)
        {
            var type = await _unitOfWork.GetRepository<ProductType, int>().GetAsync(id);
            return _mapper.Map<TypeResponseDto>(type);
        }

        public async Task<TypeResponseDto> AddAsync(TypeDto dto)
        {
            var specifications = new GetTypeByNameSpecification(dto.Name);
            if (await _unitOfWork.GetRepository<ProductType, int>().GetAsync(specifications) != null)
                throw new TypeWithNameExistException(dto.Name);

            var type = _mapper.Map<ProductType>(dto);
            _unitOfWork.GetRepository<ProductType, int>().Add(type);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TypeResponseDto>(type);
        }

        public async Task<TypeResponseDto> UpdateAsync(int id, TypeDto dto)
        {
            var existingType = await _unitOfWork.GetRepository<ProductType, int>().GetAsync(id)??
                throw new TypeNotFoundException(id);

            existingType.Name = dto.Name;

            _unitOfWork.GetRepository<ProductType, int>().Update(existingType);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TypeResponseDto>(existingType);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var type = await _unitOfWork.GetRepository<ProductType, int>().GetAsync(id) ??
                throw new TypeNotFoundException(id);

            _unitOfWork.GetRepository<ProductType, int>().Delete(type);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
