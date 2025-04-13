using AutoMapper;
using Domain.Models;
using Shared.Dtos.Products;

namespace Service.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name));

            CreateMap<ProductBrand, BrandResponseDto>();
            CreateMap<ProductType, TypeResponseDto>();
        }

    }
}
