using System;
using System.Collections.Generic;
using System.Linq;

namespace DeuceGear
{
    public static partial class EnumExtensions
    {
        public static bool EqualsSafe<T>(this Enum @enum, SafeEnum<T> safeEnum)
            where T : struct, IConvertible
        {
            return safeEnum.Equals(@enum);
        }
    }

    public struct SafeEnum<T> : IEquatable<SafeEnum<T>>
    where T : struct, IConvertible
    {
        #region Properties
        private Type _type;

        #region Info
        public bool HasFlagsAttribute => _info.HasFlagsAttribute;
        public IEnumerable<T> PossibleValues => Enums.EnumList<T>();
        private EnumTypeInfo _info;
        #endregion Info

        #region Value
        public T Value => _value;
        private T _value;
        private int _intValue;
        private Enum _enumValue;
        #endregion Value

        #endregion Properties

        #region Constructor
        public SafeEnum(int @int) : this((T)(Enum.Parse(typeof(T), @int.ToString()))){}

        public SafeEnum(T @enum)
        {
            _value = @enum;
            _type = typeof(T);
            _info = GetTypeInfo(_type);
            if (!_info.IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            _enumValue = @enum as Enum;
            _intValue = Convert.ToInt32(_value);

            if (HasFlagsAttribute)
            {
                //var intValue = _intValue;
                //for (var i = 0; i < _info.ReversedValues.Length; i++)
                //{
                //    var v = _info.ReversedValues[i];
                //    if (intValue >= v)
                //        intValue = intValue - v;
                //}
                //if (intValue != 0)
                //    throw new ArgumentException("T contains unknown flag values");
            }
            else
            {
                //if (!_info.ReversedValues.Contains(_intValue))
                //    throw new ArgumentException("T must be a valid enum value");
            }
        }
        #endregion Constructor

        #region Operators
        static public implicit operator SafeEnum<T>(T value)
        {
            return new SafeEnum<T>(value);
        }
        static public implicit operator T(SafeEnum<T> valid)
        {
            return valid._value;
        }
        static public implicit operator SafeEnum<T>(int value)
        {
            return new SafeEnum<T>(value);
        }
        static public implicit operator int(SafeEnum<T> valid)
        {
            return valid._intValue;
        }
        static public implicit operator Enum(SafeEnum<T> valid)
        {
            return valid._enumValue;
        }
        #endregion Operators

        #region Enum info caching: limits the use of reflection
        private static Dictionary<Type, EnumTypeInfo> _typeDictionary = new Dictionary<Type, EnumTypeInfo>();
        private static object _flagLock = new object();
        private static EnumTypeInfo GetTypeInfo(Type type)
        {
            if (_typeDictionary.ContainsKey(type))
                return _typeDictionary[type];
            lock (_flagLock)
            {
                if (_typeDictionary.ContainsKey(type))
                    return _typeDictionary[type];
                _typeDictionary.Add(type, new EnumTypeInfo(type));
            }
            return _typeDictionary[type];
        }

        private class EnumTypeInfo
        {
            public bool HasFlagsAttribute;
            public bool IsEnum;
            public Array SortedValues;
            public Array ReversedValues;
            public EnumTypeInfo(Type type)
            {
                HasFlagsAttribute = type.IsDefined(typeof(FlagsAttribute), false);
                IsEnum = type.IsEnum;
                if (IsEnum)
                {
                    // sorted values
                    SortedValues = type.GetEnumValues();
                    Array.Sort(SortedValues);
                    // reversed values
                    ReversedValues = Array.CreateInstance(type, SortedValues.Length); 
                    SortedValues.CopyTo(ReversedValues, 0);
                    Array.Reverse(ReversedValues);
                }
                else
                {
                    ReversedValues = Array.CreateInstance(type, 0);
                    SortedValues = Array.CreateInstance(type, 0);
                }
            }
        }
        #endregion Enum info caching: limits the use of reflection

        #region Equals
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is SafeEnum<T> t)
                return Equals(t);
            return _value.Equals(obj);
        }

        public bool Equals(SafeEnum<T> other)
        {
            return _value.Equals(other._value);
        }
        #endregion Equals

        #region ToString
        public override string ToString()
        {
            return _value.ToString();
        }
        #endregion ToString
    }
}
