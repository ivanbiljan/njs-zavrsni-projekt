using Microsoft.EntityFrameworkCore;

namespace Njs.Core.Infrastructure.Pagination;

public sealed class PaginatedList<T>
{
    public PaginatedList(int currentPage, int pageSize, int totalCount, List<T> items)
    {
        CurrentPage = currentPage;
        MaxPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
        TotalCount = totalCount;
        Items = items;
    }
    
    public int CurrentPage { get; }
    
    public int MaxPages { get; }

    public bool HasPreviousPage => MaxPages > 0 && CurrentPage > 1;

    public bool HasNextPage => CurrentPage < MaxPages;

    public List<T> Items { get; }

    public int TotalCount { get; }
}

public static class PaginatedListExtensions
{
    public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, IPageable request)
        where T : class
    {
        var pageNumber = request.PageNumber ?? 1;
        var pageSize = request.PageSize ?? Constants.DefaultPageSize;
        
        var totalCount = query.Count();

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<T>(pageNumber, pageSize, totalCount, data);
    }
}