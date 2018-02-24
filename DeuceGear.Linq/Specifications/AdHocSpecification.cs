using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace DeuseGear.Linq
{
    /// <summary>
    /// The adhoc specification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AdHocSpecification<T> : Specification<T>
    {
        private readonly Expression<Func<T, bool>> _specification;

        /// <summary>
        /// AdHocSpecification Constructor
        /// </summary>
        /// <param name="specification"></param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public AdHocSpecification(Expression<Func<T, bool>> specification)
        {
            _specification = specification;
        }

        /// <summary>
        /// Is the specification satisfied?
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> IsSatisfied()
        {
            return _specification;
        }
    }
}