namespace Njs.Core.Infrastructure.Pagination;

public abstract record PaginatedRequestBase(int PageNumber, int PageSize);