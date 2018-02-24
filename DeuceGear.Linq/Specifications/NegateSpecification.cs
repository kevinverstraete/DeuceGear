using System;
using System.Linq.Expressions;

namespace DeuseGear.Linq
{
    /// <summary>
    /// The negate specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class NegateSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec;

        /// <summary>
        /// NegateSpecification Constructor
        /// </summary>
        /// <param name="spec"></param>
        public NegateSpecification(Specification<T> spec)
        {
            _spec = spec;
        }

        /// <summary>
        /// Is the specification satisfied?
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> IsSatisfied()
        {
            return ExpressionExtensions.Not(_spec.IsSatisfied());
        }

        /// <summary>
        /// Parameters
        /// </summary>
        protected override object[] Parameters => new object[] { _spec };
    }
}