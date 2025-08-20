using System.Linq.Expressions;
using TestIdentity.Application.Common.Filters;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, List<FilterCondition> conditions)
    {
        foreach (var condition in conditions)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, condition.PropertyName);
            var constant = Expression.Constant(Convert.ChangeType(condition.Value, property.Type));

            Expression? comparison = condition.Operator switch
            {
                FilterOperator.Equals => Expression.Equal(property, constant),
                FilterOperator.NotEquals => Expression.NotEqual(property, constant),
                FilterOperator.GreaterThan => Expression.GreaterThan(property, constant),
                FilterOperator.LessThan => Expression.LessThan(property, constant),
                FilterOperator.GreaterThanOrEqual => Expression.GreaterThanOrEqual(property, constant),
                FilterOperator.LessThanOrEqual => Expression.LessThanOrEqual(property, constant),
                FilterOperator.Contains => Expression.Call(property, "Contains", null, constant),
                _ => null
            };

            if (comparison != null)
            {
                var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
                query = query.Where(lambda);
            }
        }

        return query;
    }

    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, List<SortOption> sortOptions)
    {
        if (sortOptions == null || !sortOptions.Any())
            return source;

        IOrderedQueryable<T>? orderedQuery = null;

        for (int i = 0; i < sortOptions.Count; i++)
        {
            var option = sortOptions[i];
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, option.PropertyName);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = i == 0
                ? (option.Descending ? "OrderByDescending" : "OrderBy")
                : (option.Descending ? "ThenByDescending" : "ThenBy");

            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                (orderedQuery == null ? source : orderedQuery).Expression,
                Expression.Quote(lambda)
            );

            orderedQuery = (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExpression);
        }

        return orderedQuery ?? source;
    }
}
