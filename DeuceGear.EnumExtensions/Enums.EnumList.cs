using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeuceGear
{
    public static partial class Enums
    {
        private static object _enumExtensionsPrepareListLock = new object();
        private static Dictionary<Type, Array> _enumExtensionsListDictionary = new Dictionary<Type, Array>();

        #region private dictionary methods
        internal static void EnumListPrepare(Type type)
        {
            if (_enumExtensionsListDictionary.ContainsKey(type))
                return;
            lock (_enumExtensionsPrepareListLock)
            {
                if (_enumExtensionsListDictionary.ContainsKey(type))
                    return;
                _enumExtensionsListDictionary.Add(type, type.GetEnumValues());
            }
        }

        internal static T[] EnumListClonedResult<T>(Type type)
        {
            var values = _enumExtensionsListDictionary[type];
            var result = new T[values.Length];
            values.CopyTo(result, 0);
            return result;
        }
        #endregion private dictionary methods

        /// <summary>
        /// Get a list of possible int values for a <c>Enum</c>
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns>int[] list of values</returns>
        public static int[] EnumIntList<T>() where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            EnumListPrepare(type);
            return EnumListClonedResult<int>(type);
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
