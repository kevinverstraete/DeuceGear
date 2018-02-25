using System;
using System.Linq;
using System.Linq.Expressions;

namespace DeuceGear.Linq
{
    public static partial class EnumerableExtensions
    {

        /// <summary>
        /// Implements Thenby or ThenByDescending on the given list for the given selector
        /// </summary>
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortDirection direction)
        {
            if (direction == SortDirection.Descending)
                return source.ThenByDescending(keySelector);
            return source.ThenBy(keySelector);
        }

        /// <summary>
        /// Implements Thenby or ThenByDescending on the given list for the given selector
        /// </summary>
        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SortDirection direction)
        {
            if (direction == SortDirection.Descending)
                return source.ThenByDescending(keySelector);
            return source.ThenBy(keySelector);
        }
    }
}
