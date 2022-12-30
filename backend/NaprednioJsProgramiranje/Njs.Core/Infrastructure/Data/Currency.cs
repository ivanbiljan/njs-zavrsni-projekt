namespace Njs.Core.Infrastructure.Data;

public sealed class Currency : EntityBase
{
    public string Code { get; }
    
    public string Sign { get; }
    
    public int Formatting { get; }
    
    public int DecimalPlaces { get; }
    
    public string DecimalSeparator { get; }
    
    public string GroupSeparator { get; }
}