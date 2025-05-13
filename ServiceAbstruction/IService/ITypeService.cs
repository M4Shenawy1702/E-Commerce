using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dtos.TypeDtos;

namespace ServiceAbstraction.IService
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeResponseDto>> GetAllTypesAsync();
        Task<TypeResponseDto?> GetByIdAsync(int id);
        Task<TypeResponseDto> AddAsync(TypeDto dto);
        Task<TypeResponseDto> UpdateAsync(int id, TypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
