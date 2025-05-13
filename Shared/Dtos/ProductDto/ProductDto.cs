using Microsoft.AspNetCore.Http;

namespace Shared.Dtos.ProductDto
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required IFormFile Picture { get; set; }  
        public required decimal Price { get; set; }
        public required int BrandId { get; set; }
        public required int TypeId { get; set; }
    }
}
