using App.Domain.Entities.Common;

namespace App.Domain.Entities;

public class Category : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public List<Product>? Products { get; set; }
}
