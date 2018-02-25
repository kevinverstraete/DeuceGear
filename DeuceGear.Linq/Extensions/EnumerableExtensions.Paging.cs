using System;
using System.Collections.Generic;
using System.Linq;

namespace DeuceGear.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Implement paging on the list
        /// </summary>
        public static IEnumerable<T> Paging<T>(this IEnumerable<T> source, int pageSize, int numberOfPagesToSkip)
        {
            if (pageSize <= 0)
                throw new ArgumentException("pageSize can not be 0 or less");
            if (numberOfPagesToSkip < 0)
                throw new ArgumentException("numberOfPagesToSkip can not be less than 0");
            return source.Skip(numberOfPagesToSkip * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Implement paging on the list
        /// </summary>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageSize, int numberOfPagesToSkip)
        {
            if (pageSize <= 0)
                throw new ArgumentException("pageSize can not be 0 or less");
            if (numberOfPagesToSkip < 0)
                throw new ArgumentException("numberOfPagesToSkip can not be less than 0");
            return source.Skip(numberOfPagesToSkip * pageSize).Take(pageSize);
        }
    }
}
