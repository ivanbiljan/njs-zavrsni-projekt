namespace Njs.Core.Infrastructure.Data;

public sealed class Category : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string LogoUrl { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();
}