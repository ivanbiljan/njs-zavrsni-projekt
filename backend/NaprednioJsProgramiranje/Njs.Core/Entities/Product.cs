namespace Njs.Core.Entities;

public sealed class Product : AuditableEntityBase
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int StoreId { get; init; }
    
    public Store Store { get; init; }

    public ICollection<Category> Categories { get; } = new List<Category>();
}