namespace Njs.Core.Infrastructure.Pagination;

// TODO: the type hierarchy prevents you from requesting a sorted, non paginated list 
public sealed record SortedRequestBase(int PageNumber, int PageSize) : PaginatedRequestBase(PageNumber, PageSize)
{
    public List<SortCriterion> SortCriteria { get; } = new();
}