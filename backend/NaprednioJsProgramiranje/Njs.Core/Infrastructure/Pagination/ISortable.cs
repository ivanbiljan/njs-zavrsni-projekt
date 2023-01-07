using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Njs.Core.Entities;

namespace Njs.Core.Infrastructure.Pagination;

public interface ISortable
{ 
    List<SortCriterion> SortCriteria { get; init; }
}

public static class ISortableExtensions
{
    private static IOrderedQueryable<T> ApplySorter<T>(IQueryable<T> source, SortCriterion sortCriterion)
        where T : EntityBase
    {
        return string.IsNullOrWhiteSpace(sortCriterion.SortColumn)
            ? source.OrderByProperty(null, SortDirection.Ascending)
            : source.OrderByProperty(sortCriterion.SortColumn, sortCriterion.SortDirection);
    }

    public static IOrderedQueryable<T> ApplySorters<T>(this IQueryable<T> source, ISortable? sortable)
        where T : EntityBase
    {
        if (sortable == null)
        {
            return source.OrderByProperty(null, SortDirection.Ascending);
        }

        var criteria = sortable.SortCriteria;
        source = criteria.Aggregate(source, ApplySorter);

        return (IOrderedQueryable<T>)source;
    }

    /// <summary>
    ///     Sort source by provided propertyName, defaults to Id, or first property name found
    /// </summary>
    private static IOrderedQueryable<T> OrderByProperty<T>(
        this IQueryable<T> source,
        string? propertyName,
        SortDirection sortDirection)
        where T : EntityBase
    {
        // https://github.com/dotnet/efcore/issues/27330
        var isFirst = !(source.Expression.Type.IsGenericType &&
                        source.Expression.Type.GetGenericTypeDefinition()
                            .IsAssignableTo(typeof(IOrderedQueryable<>)));
        
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            propertyName = nameof(EntityBase.Id);
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
                .Single(method => method.GetParameters().Length == 2);
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