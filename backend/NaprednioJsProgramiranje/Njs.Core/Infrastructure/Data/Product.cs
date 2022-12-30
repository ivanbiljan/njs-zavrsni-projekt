namespace Njs.Core.Infrastructure.Data;

public sealed class Product : AuditableEntityBase
{
    public string Title { get; set; }
    
    public string Description { get; set; }

    public ICollection<Category> Categories { get; } = new List<Category>();
}