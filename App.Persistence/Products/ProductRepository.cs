using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Products;

public class ProductRepository(AppDbContext context) : GenericRepository<Product, int>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count)
    {
        return await Context.Products
            .AsNoTracking()
            .OrderByDescending(x => x.Price)
            .Take(count)
            .ToListAsync();
    }
}
