using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DeuceGear.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Implements Orderby or OrderByDescending on the given list for the given selector
        /// </summary>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortDirection direction)
        {
            if (direction == SortDirection.Descending)
                return source.OrderByDescending(keySelector);
            return source.OrderBy(keySelector);
        }

        /// <summary>
        /// Implements Orderby or OrderByDescending on the given list for the given selector
        /// </summary>
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SortDirection direction)
        {
            if (direction == SortDirection.Descending)
                return source.OrderByDescending(keySelector);
            return source.OrderBy(keySelector);
        }
    }
}
