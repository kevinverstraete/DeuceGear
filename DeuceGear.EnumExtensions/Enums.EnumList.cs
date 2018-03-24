using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeuceGear
{
    public static partial class Enums
    {
        private static object _enumExtensionsPrepareListLock = new object();
        private static Dictionary<Type, Array> _enumExtensionsListValueDictionary = new Dictionary<Type, Array>();
        private static Dictionary<Type, Type> _enumExtensionsListTypeDictionary = new Dictionary<Type, Type>();

        #region private dictionary methods
        internal static void EnumListPrepare(Type type)
        {
            if (_enumExtensionsListValueDictionary.ContainsKey(type))
                return;
            lock (_enumExtensionsPrepareListLock)
            {
                if (_enumExtensionsListValueDictionary.ContainsKey(type))
                    return;
                _enumExtensionsListValueDictionary.Add(type, type.GetEnumValues());
                _enumExtensionsListTypeDictionary.Add(type, Enum.GetUnderlyingType(type));
            }
        }

        internal static T[] EnumListClonedResult<T>(Type type)
        {
            var requestType = typeof(T);
            var dictType = _enumExtensionsListTypeDictionary[type];
            if (dictType != requestType && type != requestType)
                throw new NotSupportedException($"{type.FullName} can not be converted to a list of type {requestType}");
            var values = _enumExtensionsListValueDictionary[type];
            var result = new T[values.Length];
            values.CopyTo(result, 0);
            return result;
        }
        #endregion private dictionary methods
        /// <summary>
        /// Get the list of Ttarget values contained in a <c>Enum</c>
        /// </summary>
        /// <typeparam name="Tenum">Enum type</typeparam>
        /// <typeparam name="Ttarget">Target Type</typeparam>
        /// <returns></returns>
        public static Ttarget[] EnumList<Tenum, Ttarget>() where Tenum : struct, IConvertible
        {
            var type = typeof(Tenum);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            EnumListPrepare(type);
            return EnumListClonedResult<Ttarget>(type);
        }

        /// <summary>
        /// Get the list of values contained in a <c>Enum</c>
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns>T[] list of values</returns>
        public static IEnumerable<T> EnumList<T>() where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            EnumListPrepare(type);
            return EnumListClonedResult<T>(type);
        }
    }
}
