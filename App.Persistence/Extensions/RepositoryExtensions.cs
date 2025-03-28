﻿using App.Application.Contracts.Persistence;
using App.Domain.Options;
using App.Persistence.Categories;
using App.Persistence.Interceptors;
using App.Persistence.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Persistence.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoriesExt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

            options.UseNpgsql(connectionStrings!.DefaultConnection, options =>
            {
                options.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
            });

            options.AddInterceptors(new AuditDbContextInterceptor());
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
