using System;

namespace DeuceGear
{
    /// <summary>
    /// EnumValueAttribute gives the possibility to link one or more string values to an enumerator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        /// <summary>
        /// The attribute value
        /// </summary>
        public string Value
        {
            get { return _enumValue; }
        }
        private readonly string _enumValue;

        /// <summary>
        /// Initializes a new instance of the class <c>EnumValueAttribute</c> with default value (empty string)
        /// </summary>
        public EnumValueAttribute() : this(string.Empty) { }

        /// <summary>
        /// Initializes a new instance of the class <c>EnumValueAttribute</c> with specified value
        /// </summary>
        /// <param name="value">
        /// The value of this attribute
        /// </param>
        public EnumValueAttribute(string value) {
            _enumValue = value;
        }

        /// <summary>
        /// Determines whether this instance and another specified <c>EnumValueAttribute</c> object have the same value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// True if obj equals the type and string value of this instance; Otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is EnumValueAttribute dsaObj)
            {
                if (_enumValue == null && dsaObj._enumValue == null)
                    return true;
                if (_enumValue == null)
                    return false;
                return _enumValue.Equals(dsaObj._enumValue);
            }
            return false;
        }

        /// <summary>
        /// Returns the hascode for this <c>EnumValueAttribute</c>
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return _enumValue.GetHashCode();
        }

        #region Default
        /// <summary>
        /// The default value for the attribute <c>EnumValueAttribute</c>, which is an empty string
        /// </summary>
        public static readonly EnumValueAttribute Default = new EnumValueAttribute();

        /// <summary>
        /// Indicates whether the value of this instance, is the default value for the <c>EnumValueAttribute</c>
        /// </summary>
        /// <returns>
        /// True if this instance is the default attribute for the class; Otherwise, false.
        /// </returns>
        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
        #endregion Default
    }
}