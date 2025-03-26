using App.Application.Features.Products.Create;
using App.Application.Features.Products.Dto;
using App.Application.Features.Products.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Products;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<UpdateProductRequest, Product>().
            ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<CreateProductRequest, Product>();
    }
}
