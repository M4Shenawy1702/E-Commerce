using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.IService;
using Shared.Dtos.TypeDtos;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController(IServiceManager _serviceManager)
                : APIController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeResponseDto>>> GetAllTypes()
        {
            var types = await _serviceManager.TypeService.GetAllTypesAsync();
            return Ok(types);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeResponseDto>> GetTypeById(int id)
        {
            var type = await _serviceManager.TypeService.GetByIdAsync(id);
            if (type == null)
                return NotFound();
            return Ok(type);
        }
        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<TypeResponseDto>> CreateType([FromBody] TypeDto typeDto)
        {
            var createdType = await _serviceManager.TypeService.AddAsync(typeDto);
            return CreatedAtAction(nameof(GetTypeById), new { id = createdType.Id }, createdType);
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeResponseDto>> UpdateType(int id, [FromBody] TypeDto typeDto)
        {
            var type = await _serviceManager.TypeService.UpdateAsync(id, typeDto);
            return Ok(type);
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteType(int id)
        {
            var result = await _serviceManager.TypeService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
