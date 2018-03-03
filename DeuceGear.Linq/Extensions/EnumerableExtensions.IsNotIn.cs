using System.Collections.Generic;
using System.Linq;

namespace DeuceGear.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Syntactic Sugar for source.Where(x => !list.Contains(x));
        /// </summary>
        public static IEnumerable<TSource> IsNotIn<TSource>(this IEnumerable<TSource> source, params TSource[] list)
        {
            return source.Where(x => !list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => !list.Contains(x));
        /// </summary>
        public static IQueryable<TSource> IsNotIn<TSource>(this IQueryable<TSource> source, params TSource[] list)
        {
            return source.Where(x => !list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => !list.Contains(x));
        /// </summary>
        public static IEnumerable<TSource> IsNotIn<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> list)
        {
            if (list == null)
                list = new List<TSource>();
            return source.Where(x => !list.Contains(x));
        }

        /// <summary>
        /// Syntactic Sugar for source.Where(x => !list.Contains(x));
        /// </summary>
        public static IQueryable<TSource> IsNotIn<TSource>(this IQueryable<TSource> source, IEnumerable<TSource> list)
        {
            if (list == null)
                list = new List<TSource>();
            return source.Where(x => !list.Contains(x));
        }
    }
}
