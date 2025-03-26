using App.Application.Features.Categories;
using App.Application.Features.Categories.Create;
using App.Application.Features.Categories.Update;
using Microsoft.AspNetCore.Mvc;
namespace App.API.Controllers;

public class CategoriesController(ICategoryService categoryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetCategoryWithProducts(int categoryId) => CreateActionResult(await categoryService.GetCategoryWithProductsAsync(categoryId));

    [HttpGet]
    public async Task<IActionResult> GetCategoriesWithProducts() => CreateActionResult(await categoryService.GetCategoriesWithProductsAsync());

    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await categoryService.GetAllAsync());

    [HttpGet]
    public async Task<IActionResult> GetById(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(request));

    [HttpDelete]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await categoryService.DeleteAsync(id));
}
