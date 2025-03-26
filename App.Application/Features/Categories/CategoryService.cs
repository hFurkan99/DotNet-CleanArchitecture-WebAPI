using App.Application.Contracts.Persistence;
using App.Application.Features.Categories.Create;
using App.Application.Features.Categories.Dto;
using App.Application.Features.Categories.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Categories;

public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    public async Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int categoryId)
    {
        var category = await categoryRepository.GetCategoryWithProductsAsync(categoryId);

        if(category is null) 
            return ServiceResult<CategoryWithProductsDto>.Fail("Kategori bulunamadı.", HttpStatusCode.NotFound);
        
        var categoryAsDto = mapper.Map<CategoryWithProductsDto>(category);
        return ServiceResult<CategoryWithProductsDto>.Success(categoryAsDto);
    }

    public async Task<ServiceResult<IEnumerable<CategoryWithProductsDto>>> GetCategoriesWithProductsAsync()
    {
        var categories = await categoryRepository.GetCategoriesWithProductsAsync();
        var categoriesAsDto = mapper.Map<IEnumerable<CategoryWithProductsDto>>(categories);

        return ServiceResult<IEnumerable<CategoryWithProductsDto>>.Success(categoriesAsDto);
    }

    public async Task<ServiceResult<IEnumerable<CategoryDto>>> GetAllAsync()
    {
        var categories = await categoryRepository.GetAllAsync();
        var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);

        return ServiceResult<IEnumerable<CategoryDto>>.Success(categoriesAsDto);
    }

    public async Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);

        if (category is null) return
            ServiceResult<CategoryDto?>.Fail("Category not found", HttpStatusCode.NotFound);

        var categoryAsDto = mapper.Map<CategoryDto>(category);

        return ServiceResult<CategoryDto>.Success(categoryAsDto)!;
    }

    public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
    {
        var isCategoryNameExist = await categoryRepository.AnyAsync(x => x.Name == request.Name);
        if (isCategoryNameExist)
            return ServiceResult<int>.Fail("Kategori ismi veritabanında bulunmaktadır.");

        var category = mapper.Map<Category>(request);

        await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<int>.SuccessAsCreated(category.Id, $"/api/Categories/GetById?id={category.Id}");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateCategoryRequest request)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id);
        if (category is null)
            return ServiceResult.Fail("Category not found", HttpStatusCode.NotFound);

        var isCategoryNameExist = await categoryRepository
            .AnyAsync(x => x.Name == request.Name && x.Id != category.Id);
        if (isCategoryNameExist)
            return ServiceResult.Fail("Kategori ismi veritabanında bulunmaktadır.");

        mapper.Map(request, category);

        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null) return ServiceResult.Fail("Category not found", HttpStatusCode.NotFound);

        categoryRepository.Delete(category!);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}
