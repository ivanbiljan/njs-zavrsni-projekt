using Microsoft.EntityFrameworkCore;

namespace Njs.Core.Infrastructure.Pagination;

public sealed class PaginatedList<T>
{
    public PaginatedList(int currentPage, int totalCount, List<T> items)
    {
        CurrentPage = currentPage;
        MaxPages = (int)Math.Ceiling((decimal)totalCount / items.Count);
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
        var totalCount = query.Count();

        var data = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PaginatedList<T>(request.PageNumber, totalCount, data);
    }
}