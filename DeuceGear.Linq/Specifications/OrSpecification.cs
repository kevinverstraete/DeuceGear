using System;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

namespace DeuseGear.Linq
{
    /// <summary>
    /// The or specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec1;
        private readonly Specification<T> _spec2;

        /// <summary>
        /// OrSpecification Constructor
        /// </summary>
        /// <param name="spec1"></param>
        /// <param name="spec2"></param>
        public OrSpecification(Specification<T> spec1, Specification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }

        /// <summary>
        /// Parameters
        /// </summary>
        //[ExcludeFromCodeCoverage]
        protected override object[] Parameters => new object[] { _spec1, _spec2 };

        /// <summary>
        /// Is the specification satisfied?
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> IsSatisfied()
        {
            var expression1 = _spec1.IsSatisfied();
            var expression2 = _spec2.IsSatisfied();
            return expression1.Or(expression2);
        }
    }
}