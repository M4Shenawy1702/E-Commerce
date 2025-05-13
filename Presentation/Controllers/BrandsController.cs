using ServiceAbstraction.IService;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.BrandDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IServiceManager _serviceManager) : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _serviceManager.BrandService.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandResponseDto>> GetBrandById(int id)
        {
            var brand = await _serviceManager.BrandService.GetByIdAsync(id);
            return Ok(brand);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<BrandResponseDto>> AddBrand([FromBody] BrandDto brandDto)
        {
            var brand = await _serviceManager.BrandService.AddAsync(brandDto);
            return CreatedAtAction(nameof(GetBrandById), new { id = brand.Id }, brand);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<BrandResponseDto>> UpdateBrand(int id, [FromBody] BrandDto brandDto)
        {
            var brand = await _serviceManager.BrandService.UpdateAsync(id, brandDto);
            return Ok(brand);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBrand(int id)
        {
            var result = await _serviceManager.BrandService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
