using Shared.Dtos.BrandDtos;

namespace ServiceAbstraction.IService
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResponseDto>> GetAllAsync();
        Task<BrandResponseDto?> GetByIdAsync(int id);
        Task<BrandResponseDto> AddAsync(BrandDto dto);
        Task<BrandResponseDto> UpdateAsync(int id, BrandDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
