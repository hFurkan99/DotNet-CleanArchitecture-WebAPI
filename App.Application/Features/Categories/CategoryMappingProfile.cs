using App.Application.Features.Categories.Create;
using App.Application.Features.Categories.Dto;
using App.Application.Features.Categories.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Categories;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryDto, Category>()
            .ReverseMap();

        CreateMap<CategoryWithProductsDto, Category>()
            .ReverseMap();
        
        CreateMap<CreateCategoryRequest, Category>();

        CreateMap<UpdateCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
