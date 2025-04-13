using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Shared.Dtos.Products;

namespace Service.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<PictureUrlResolver>());

            CreateMap<ProductBrand, BrandResponseDto>();
            CreateMap<ProductType, TypeResponseDto>();
        }

    }
}
internal class PictureUrlResolver(IConfiguration _configrations)
    : IValueResolver<Product, ProductResponseDto, string>
{
    public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return $"{_configrations["BaseUrl"]}{source.PictureUrl}";
        }
        return "";
    }
}
