namespace Njs.Core.Infrastructure.Data;

public interface IMustHaveTenant
{
    string TenantId { get; set; }
}