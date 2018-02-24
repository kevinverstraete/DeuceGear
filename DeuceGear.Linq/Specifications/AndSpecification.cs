using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace DeuseGear.Linq
{
    /// <summary>
    /// The and specification
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec1;

        private readonly Specification<T> _spec2;

        /// <summary>
        /// AndSpecification Constructor
        /// </summary>
        /// <param name="spec1"></param>
        /// <param name="spec2"></param>
        public AndSpecification(Specification<T> spec1, Specification<T> spec2)
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

            return expression1.And(expression2);
        }
    }
}