using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DeuceGear.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x));
        /// </summary>
        public static IEnumerable<TSource> IsIn<TSource>(this IEnumerable<TSource> source, params TSource[] list)
        {
            return source.Where(x => list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x));
        /// </summary>
        public static IQueryable<TSource> IsIn<TSource>(this IQueryable<TSource> source, params TSource[] list)
        {
            return source.Where(x => list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x));
        /// </summary>
        public static IEnumerable<TSource> IsIn<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> list)
        {
            if (list == null)
                list = new List<TSource>();
            return source.Where(x => list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x));
        /// </summary>
        public static IQueryable<TSource> IsIn<TSource>(this IQueryable<TSource> source, IEnumerable<TSource> list)
        {
            if (list == null)
                list = new List<TSource>();
            return source.Where(x => list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x.Value));
        /// </summary>
        public static IEnumerable<TSource> IsIn<TSource, TKey>(this IEnumerable<TSource> source, Expression<Func<TSource, TKey>> selector,params TKey[] list)
        {
            return source.Where(x => list.Contains(selector.Compile().Invoke(x)));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x.Value));
        /// </summary>
        public static IQueryable<TSource> IsIn<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> selector, params TKey[] list)
        {
            return source.Where(x => list.Contains(selector.Compile().Invoke(x)));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x.Value));
        /// </summary>
        public static IEnumerable<TSource> IsIn<TSource, TKey>(this IEnumerable<TSource> source, Expression<Func<TSource, TKey>> selector, IEnumerable<TKey> list)
        {
            return source.Where(x => list.Contains(selector.Compile().Invoke(x)));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => list.Contains(x.Value));
        /// </summary>
        public static IQueryable<TSource> IsIn<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> selector, IEnumerable<TKey> list)
        {
            return source.Where(x => list.Contains(selector.Compile().Invoke(x)));
        }
    }
}
