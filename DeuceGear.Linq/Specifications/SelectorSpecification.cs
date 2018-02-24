using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DeuseGear.Linq
{
    public class SelectorSpecification<TSource, TValue> : Specification<TSource>
    {
        public Expression<Func<TSource, TValue>> Selector { get; private set; }
        public TValue Value { get; private set; }
        public bool ValidateIfNull { get; set; }
        public Operation Operation { get; private set; }

        public SelectorSpecification(Expression<Func<TSource, TValue>> selector, Operation operation, TValue value, bool validateIfNull = true)
        {
            Selector = selector;
            Value = value;
            ValidateIfNull = validateIfNull;
            Operation = operation;
        }

        public SelectorSpecification(Expression<Func<TSource, TValue>> selector, TValue value, bool validateIfNull = true) 
            : this(selector, Operation.Equals, value, validateIfNull)
        {
        }

        public override Expression<Func<TSource, bool>> IsSatisfied()
        {
            if (!ValidateIfNull)
                if (Value == null)
                    return x => true;

            Expression expression = null;
            switch (Operation)
            {
                case Operation.Contains:
                    if (typeof(TValue) != typeof(string))
                        throw new NotSupportedException("Contains only works for strings");
                    var constantContains = Expression.Constant(Value, typeof(string));
                    var methodInfoContains = typeof(string).GetMethod(nameof(string.Contains), new Type[] { typeof(string) });
                    expression = Expression.Call(Selector.Body, methodInfoContains, constantContains);
                    break;
                case Operation.StartsWith:
                    if (typeof(TValue) != typeof(string))
                        throw new NotSupportedException("StartsWith only works for strings");
                    var constantStart = Expression.Constant(Value, typeof(string));
                    var methodInfoStart = typeof(string).GetMethod(nameof(string.StartsWith), new Type[] { typeof(string) });
                    expression = Expression.Call(Selector.Body, methodInfoStart, constantStart);
                    break;
                case Operation.EndsWith:
                    if (typeof(TValue) != typeof(string))
                        throw new NotSupportedException("EndsWith only works for strings");
                    var constantEnd = Expression.Constant(Value, typeof(string));
                    var methodInfoEnd = typeof(string).GetMethod(nameof(string.EndsWith), new Type[] { typeof(string) });
                    expression = Expression.Call(Selector.Body, methodInfoEnd, constantEnd);
                    break;
                case Operation.NotEquals:
                    expression = Expression.NotEqual(Selector.Body, Expression.Constant(Value, typeof(TValue)));
                    break;
                case Operation.GreaterThan:
                    if (typeof(TValue) != typeof(string))
                        expression = Expression.GreaterThan(Selector.Body, Expression.Constant(Value, typeof(TValue)));
                    else
                    {
                        var constantGreaterThan = Expression.Constant(Value, typeof(string));
                        var methodInfoGreaterThan = typeof(string).GetMethod(nameof(string.CompareTo), new Type[] { typeof(string) });
                        var compareGreaterThan = Expression.Call(Selector.Body, methodInfoGreaterThan, constantGreaterThan);
                        expression = Expression.GreaterThan(compareGreaterThan, Expression.Constant(0, typeof(int)));

                    }
                    break;
                case Operation.GreaterThanOrEquals:
                    if (typeof(TValue) != typeof(string))
                        expression = Expression.GreaterThanOrEqual(Selector.Body, Expression.Constant(Value, typeof(TValue)));
                    else
                    {
                        var constantGreaterThanOrEqual = Expression.Constant(Value, typeof(string));
                        var methodInfoGreaterThanOrEqual = typeof(string).GetMethod(nameof(string.CompareTo), new Type[] { typeof(string) });
                        var compareGreaterThanOrEqual = Expression.Call(Selector.Body, methodInfoGreaterThanOrEqual, constantGreaterThanOrEqual);
                        expression = Expression.GreaterThanOrEqual(compareGreaterThanOrEqual, Expression.Constant(0, typeof(int)));
                    }
                    break;
                case Operation.LessThan:
                    if (typeof(TValue) != typeof(string))
                        expression = Expression.LessThan(Selector.Body, Expression.Constant(Value, typeof(TValue)));
                    else
                    {
                        var constantLessThan = Expression.Constant(Value, typeof(string));
                        var methodInfoLessThan = typeof(string).GetMethod(nameof(string.CompareTo), new Type[] { typeof(string) });
                        var compareLessThan = Expression.Call(Selector.Body, methodInfoLessThan, constantLessThan);
                        expression = Expression.LessThan(compareLessThan, Expression.Constant(0, typeof(int)));
                    }
                    break;
                case Operation.LessThanOrEquals:
                    if (typeof(TValue) != typeof(string))
                        expression = Expression.LessThanOrEqual(Selector.Body, Expression.Constant(Value, typeof(TValue)));
                    else
                    {
                        var constantLessThanOrEqual = Expression.Constant(Value, typeof(string));
                        var methodInfoLessThanOrEqual = typeof(string).GetMethod(nameof(string.CompareTo), new Type[] { typeof(string) });
                        var compareLessThanOrEqual = Expression.Call(Selector.Body, methodInfoLessThanOrEqual, constantLessThanOrEqual);
                        expression = Expression.LessThanOrEqual(compareLessThanOrEqual, Expression.Constant(0, typeof(int)));
                    }
                    break;
                default:
                    expression = Expression.Equal(Selector.Body, Expression.Constant(Value, typeof(TValue)));
                    break;
            }

            return Expression.Lambda<Func<TSource, bool>>(expression, Selector.Parameters);
        }
    }

    public enum Operation
    {
        Equals,
        Contains,
        StartsWith,
        EndsWith,
        NotEquals,
        GreaterThan,
        GreaterThanOrEquals,
        LessThan,
        LessThanOrEquals
    }
}
