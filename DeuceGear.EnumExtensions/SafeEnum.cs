using System;
using System.Collections.Generic;
using System.Linq;

namespace DeuceGear
{
    public class SafeEnum<T> where T : struct, IConvertible
    {
        private T _enum;
        private Type _type;
        private EnumTypeInfo _info;
        public bool HasFlagsAttribute => _info.HasFlagsAttribute;
        public IList<T> PossibleValues => _info.SortedValues.Cast<T>().ToList();
        public T Value => _enum;
        public SafeEnum(T @enum)
        {
            _enum = @enum;
            _type = typeof(T);
            _info = GetEnumTypeInfo(_type);

            if (!_info.IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            var intValue = Convert.ToInt32(_enum);
            if (HasFlagsAttribute)
            {
                for (var i = 0; i < _info.ReversedValues.Count; i++)
                {
                    var v = _info.ReversedValues[i];
                    if (intValue >= v)
                        intValue = intValue - v;
                }
                if (intValue != 0)
                    throw new ArgumentException("T contains unknown flag values");
            }
            else
            {
                if (!_info.ReversedValues.Contains(intValue))
                    throw new ArgumentException("T must be a value enum value");
            }
        }

        static public implicit operator SafeEnum<T>(T value)
        {
            return new SafeEnum<T>(value);
        }

        static public implicit operator T(SafeEnum<T> valid)
        {
            return valid._enum;
        }

        #region flag caching, limit the use of reflection
        private static Dictionary<Type, EnumTypeInfo> _typeDictionary = new Dictionary<Type, EnumTypeInfo>();
        private static object _flagLock = new object();
        private static EnumTypeInfo GetEnumTypeInfo(Type type)
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
            public IList<int> ReversedValues;
            public IList<int> SortedValues;
            public EnumTypeInfo(Type type)
            {
                HasFlagsAttribute = type.IsDefined(typeof(FlagsAttribute), false);
                IsEnum = type.IsEnum;
                if (IsEnum)
                {
                    var values = ((int[])Enum.GetValues(type));
                    SortedValues = values.OrderBy(x => x).ToList().AsReadOnly();
                    ReversedValues = values.OrderByDescending(x => x).ToList().AsReadOnly();
                }
                else
                {
                    ReversedValues = new List<int>();
                    SortedValues = new List<int>();
                }
            }
        }
        #endregion flag caching, limit the use of reflection
    }
}
