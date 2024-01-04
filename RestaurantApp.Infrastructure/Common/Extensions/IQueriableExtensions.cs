using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications;
using System.Linq.Expressions;
using System.Reflection;

namespace RestaurantApp.Infrastructure.Common.Extensions
{
    public static class IQueriableExtensions
    {
        public static IQueryable<R> ProjectTo<T, R>(this IQueryable<T> queryable, IMapper mapper)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            return queryable.ProjectTo<R>(mapper.ConfigurationProvider);
        }

        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> queriable, int pageNumber = -1, int pageSize = -1)
        {
            var count = queriable.Count();

            if(pageNumber > 0 && pageSize > 0)
            {
                queriable = queriable.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            var items = await queriable.ToListAsync();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, string? propertyName = null, bool ascending = true)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return queryable;
            }

            var entityType = typeof(T);
            var property = entityType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
            {
                return queryable;
            }

            var parameter = Expression.Parameter(entityType, "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            string methodName = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = { entityType, property.PropertyType };

            var orderByMethod = typeof(Queryable).GetMethods()
                .Where(m => m.Name == methodName && m.IsGenericMethodDefinition && m.GetParameters().Length == 2)
                .Single()
                .MakeGenericMethod(types);

            return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { queryable, orderByExpression });
        }

        public static IQueryable<T> Tracking<T>(this IQueryable<T> queriable, bool tracking)
            where T : class
        {
            if (!tracking)
            {
                return queriable.AsNoTracking();
            }

            return queriable;
        }

        public static IQueryable<T> Filter<T>(this IQueryable<T> queriable, Specification<T>? filter)
        {
            if(filter == null)
            {
                return queriable;
            }

            return queriable.Where(filter.ToExpression());
        }
    }
}
