using System;
using System.Linq;
using System.Reflection;

namespace DeuseGear.Linq
{
    /// <summary>
    /// Extension methods on Specifications that can be used during unittesting
    /// </summary>
    public static class SpecificationExtensions
    {
        /// <summary>
        /// Method that will check if two Specifications are the same
        /// </summary>
        /// <param name="specification">First specification to compare</param>
        /// <param name="other">Second specification to compare</param>
        /// <typeparam name="T">Type the specification is about</typeparam>
        /// <returns>true if both specifications are the same, otherwise false</returns>
        public static bool IsSameAs<T>(this Specification<T> specification, Specification<T> other)
        {
            if (ReferenceEquals(specification, other))
                return true;
            if (other == null)
                return false;

            return specification.GetType() == other.GetType() 
                && SpecificationsContainSameFields(specification, other);
        }

        private static bool SpecificationsContainSameFields<T>(Specification<T> specification, Specification<T> other)
        {
            var fields =
                specification.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            return fields.All(field =>
            {
                var specificationValue = field.GetValue(specification);
                var otherValue = field.GetValue(other);

                if (specificationValue == null && otherValue == null)
                    return true;

                if (specificationValue != null & otherValue != null)
                {
                    if (field.FieldType == typeof(Specification<T>))
                    {
                        var specificationValueForSame = (Specification<T>)specificationValue;
                        return specificationValueForSame.IsSameAs((Specification<T>)otherValue);
                    }
                }

                if (field.FieldType.IsArray)
                {
                    var specificationArray = specificationValue as Array;
                    var otherArray = otherValue as Array;

                    if (specificationArray == null || otherArray == null)
                        return false;

                    if (specificationArray.Length != otherArray.Length)
                        return false;

                    for (int i = 0; i < otherArray.Length; i++)
                    {
                        var specVal = specificationArray.GetValue(i);
                        var otherVal = otherArray.GetValue(i);
                        if (specVal == null || otherVal == null) return false;
                        if (specVal.GetType() != otherVal.GetType()) return false;
                        if (!specVal.Equals(otherVal)) return false;
                    }

                    return true;
                }

                return specificationValue != null && specificationValue.Equals(otherValue);
            });
        }
    }
}