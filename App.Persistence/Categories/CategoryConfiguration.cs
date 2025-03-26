using App.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Categories;

public class CategoryConfiguration
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
    }
}
