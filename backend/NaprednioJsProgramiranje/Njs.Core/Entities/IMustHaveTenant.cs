namespace Njs.Core.Entities;

public interface IMustHaveTenant
{
    string TenantId { get; set; }
}