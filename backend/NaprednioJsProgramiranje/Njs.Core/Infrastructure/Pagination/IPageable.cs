namespace Njs.Core.Infrastructure.Pagination;

public interface IPageable
{ 
    int? PageNumber { get; init; }
    
    int? PageSize { get; init; }
}