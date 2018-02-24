using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace DeuseGear.Linq
{
    /// <summary>
    /// Extension methods on Expressions
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Join 2 expressions using AndAlso
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="expressionToAdd"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> expressionToAdd)
        {
            if (expressionToAdd == null)
                throw new ArgumentNullException(nameof(expressionToAdd));

            expressionToAdd = expressionToAdd.ReplaceParameter(expressionToAdd.Parameters.First(), expression.Parameters.First());
            var binExp = Expression.AndAlso(expression.Body, expressionToAdd.Body);
            return Expression.Lambda<Func<T, bool>>(binExp, expressionToAdd.Parameters);
        }

        /// <summary>
        /// Join 2 expressions using OrElse
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="expressionToOr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> expressionToOr)
        {
            if (expressionToOr == null)
                throw new ArgumentNullException(nameof(expressionToOr));

            expressionToOr = expressionToOr.ReplaceParameter(expressionToOr.Parameters.First(), expression.Parameters.First());
            var binExp = Expression.OrElse(expression.Body, expressionToOr.Body);
            return Expression.Lambda<Func<T, bool>>(binExp, expressionToOr.Parameters);
        }

        /// <summary>
        /// Negate the given expression
        /// </summary>
        /// <param name="expressionToNot"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expressionToNot)
        {
            if (expressionToNot == null)
                throw new ArgumentNullException(nameof(expressionToNot));

            var par = expressionToNot.Parameters;
            var body = Expression.Not(expressionToNot.Body);

            return Expression.Lambda<Func<T, bool>>(body, par);
        }

        /// <summary>
        /// Replaces the old Parameter in the expression with the new parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="oldParameter"></param>
        /// <param name="newParameter"></param>
        /// <returns></returns>
        public static Expression<T> ReplaceParameter<T>(this Expression<T> expression, ParameterExpression oldParameter, ParameterExpression newParameter)
        {
            var visitor = new ParameterUpdateVisitor(expression.Parameters.First(), newParameter);
            return visitor.Visit(expression) as Expression<T>;
        }

        private class ParameterUpdateVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _oldExpression;
            private readonly ParameterExpression _newExpression;

            public ParameterUpdateVisitor(ParameterExpression oldPar, ParameterExpression newPar)
            {
                _oldExpression = oldPar;
                _newExpression = newPar;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return ReferenceEquals(node, _oldExpression) ? _newExpression : base.VisitParameter(node);
            }
        }

    }
}