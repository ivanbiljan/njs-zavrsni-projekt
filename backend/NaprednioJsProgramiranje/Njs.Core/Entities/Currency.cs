﻿namespace Njs.Core.Entities;

public sealed class Currency : EntityBase
{
    public string Code { get; }
    
    public string Sign { get; }
    
    public int Formatting { get; }
    
    public int DecimalPlaces { get; }
    
    public string DecimalSeparator { get; }
    
    public string GroupSeparator { get; }

    public ICollection<Store> Stores { get; private set; } = new List<Store>();
}