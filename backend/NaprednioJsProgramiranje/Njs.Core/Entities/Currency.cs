namespace Njs.Core.Entities;

public sealed class Currency : EntityBase
{
    public string Code { get; init; }
    
    public string Sign { get; init; }
    
    public int Formatting { get; init; }
    
    public int DecimalPlaces { get; init; }
    
    public string DecimalSeparator { get; init; }
    
    public string GroupSeparator { get; init; }

    public ICollection<Store> Stores { get; init; } = new List<Store>();
}