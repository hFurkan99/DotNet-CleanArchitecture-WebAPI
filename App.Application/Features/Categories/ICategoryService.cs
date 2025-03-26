using App.Application.Features.Categories.Create;
using App.Application.Features.Categories.Dto;
using App.Application.Features.Categories.Update;

namespace App.Application.Features.Categories;

public interface ICategoryService
{
    Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int categoryId);
    Task<ServiceResult<IEnumerable<CategoryWithProductsDto>>> GetCategoriesWithProductsAsync();
    Task<ServiceResult<IEnumerable<CategoryDto>>> GetAllAsync();
    Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id);
    Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
    Task<ServiceResult> UpdateAsync(UpdateCategoryRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}
