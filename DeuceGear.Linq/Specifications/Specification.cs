using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace DeuseGear.Linq
{
    public abstract class Specification<T>
    {
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public abstract Expression<Func<T, bool>> IsSatisfied();

        public static Specification<T> operator &(Specification<T> spec1, Specification<T> spec2)
        {
            return new AndSpecification<T>(spec1, spec2);
        }

        public static Specification<T> operator |(Specification<T> spec1, Specification<T> spec2)
        {
            return new OrSpecification<T>(spec1, spec2);
        }

        public static Specification<T> operator !(Specification<T> spec1)
        {
            return new NegateSpecification<T>(spec1);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "This is required!")]
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        public static bool operator false(Specification<T> spec1)
        {
            return false; // no-op. & and && do exactly the same thing.
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "This is required!")]
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        public static bool operator true(Specification<T> spec1)
        {
            return false; // no - op. & and && do exactly the same thing.
        }

        public bool Equals(Specification<T> other)
        {
            return SpecificationExtensions.IsSameAs(this, other);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is Specification<T> spec) return Equals(spec);
            return false;
        }

        protected virtual object[] Parameters => new object[] { Guid.NewGuid() };
        public override int GetHashCode()
        {
            return Parameters.GetHashCode();
        }
    }
}