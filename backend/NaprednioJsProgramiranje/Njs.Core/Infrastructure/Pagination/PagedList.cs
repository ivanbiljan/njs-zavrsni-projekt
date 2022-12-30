using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Njs.Core.Infrastructure.Pagination;

public class PaginatedList<T>
{
    public PaginatedList(int totalCount, List<T> items)
    {
        TotalCount = totalCount;
        Items = items;
    }

    public List<T> Items { get; }

    public int TotalCount { get; }
}

public static class PaginatedListExtensions
{
    public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, PaginatedRequestBase request)
        where T : class
    {
        var totalCount = query.Count();

        var data = await query
            .ApplySorters(request as SortedRequestBase)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PaginatedList<T>(totalCount, data);
    }

    private static IOrderedQueryable<T> ApplySorter<T>(IQueryable<T> source, SortCriterion sortCriterion)
        where T : class
    {
        return string.IsNullOrWhiteSpace(sortCriterion.SortColumn)
            ? source.OrderByProperty(null, SortDirection.Ascending)
            : source.OrderByProperty(sortCriterion.SortColumn, sortCriterion.SortDirection);
    }

    private static IOrderedQueryable<T> ApplySorters<T>(this IQueryable<T> source, SortedRequestBase? sortedListRequest)
        where T : class
    {
        if (sortedListRequest == null)
        {
            return source.OrderByProperty(null, SortDirection.Ascending);
        }

        var criteria = sortedListRequest.SortCriteria;
        source = criteria.Aggregate(source, ApplySorter);

        return (IOrderedQueryable<T>)source;
    }

    /// <summary>
    ///     Get primary key name or first property name if no primary key is defined
    /// </summary>
    private static string GetDefaultPropertyName<T>()
        where T : class
    {
        var properties = typeof(T).GetProperties();

        var key = properties.FirstOrDefault(p => p.IsDefined(typeof(KeyAttribute))) ?? properties.FirstOrDefault();

        return key!.Name;
    }

    /// <summary>
    ///     Sort source by provided propertyName, defaults to Id, or first property name found
    /// </summary>
    private static IOrderedQueryable<T> OrderByProperty<T>(
        this IQueryable<T> source,
        string? propertyName,
        SortDirection sortDirection)
        where T : class
    {
        // https://github.com/dotnet/efcore/issues/27330
        var isFirst = !(source.Expression.Type.IsGenericType &&
                        source.Expression.Type.GetGenericTypeDefinition()
                            .IsAssignableTo(typeof(IOrderedQueryable<>)));
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            propertyName = GetDefaultPropertyName<T>();
        }

        // construct lambda key selector
        var parameter = Expression.Parameter(typeof(T), "x");
        var orderByProperty = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda(orderByProperty, parameter);

        // instantiate OrderBy method
        var typeArguments = new[]
        {
            typeof(T), orderByProperty.Type
        };

        var genericMethod = GetOrderMethod().MakeGenericMethod(typeArguments);
        var methodResult = genericMethod.Invoke(
            null,
            new object[]
            {
                source, lambda
            });

        return (IOrderedQueryable<T>)methodResult!;

        MethodInfo GetOrderMethod()
        {
            var methodName = GetMethodName();

            return typeof(Queryable)
                .GetMethods()
                .Where(method => method.Name == methodName)
                .Where(method => method.GetParameters().Length == 2)
                .Single();
        }

        string GetMethodName()
        {
            if (isFirst)
            {
                return sortDirection == SortDirection.Descending
                    ? nameof(Queryable.OrderByDescending)
                    : nameof(Queryable.OrderBy);
            }

            return sortDirection == SortDirection.Descending
                ? nameof(Queryable.ThenByDescending)
                : nameof(Queryable.ThenBy);
        }
    }
}