using DeuceGear.Comparers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeuceGear
{
    public static partial class ObjectExtensions
    {
        private static readonly MethodInfo CloneMethod = typeof(object).GetMethod(nameof(MemberwiseClone), BindingFlags.NonPublic | BindingFlags.Instance);

        /// <summary>
        /// Determine if object is a primitive value type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static bool IsPrimitiveValueType(this object obj)
        {
            return IsPrimitiveValueType(obj.GetType());
        }
        /// <summary>
        /// Determine if type is a primitive value type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsPrimitiveValueType(this Type type)
        {
            var typeinfo = type.GetTypeInfo();
            if (type == typeof(string))
                return true;
            return (typeinfo.IsValueType & typeinfo.IsPrimitive);
        }

        /// <summary>
        /// Copy the given object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T original)
        {
            return (T)InternalCopy(original, new Dictionary<object, object>(new ReferenceEqualityComparer()));
        }

        private static object InternalCopy(object originalObject, IDictionary<object, object> visited)
        {
            // null object just returns as null
            if (originalObject == null)
                return null;
            // value types return as a itself. It is always by value
            var typeToReflect = originalObject.GetType();
            if (IsPrimitiveValueType(typeToReflect))
                return originalObject;
            // object already in memory from previous copy, return the new instance.
            if (visited.ContainsKey(originalObject))
                return visited[originalObject];
            // delegate methods are not copied
            if (typeof(Delegate).IsAssignableFrom(typeToReflect))
                return null;
            // create a new object
            var cloneObject = CloneMethod.Invoke(originalObject, null);
            // loop array and copy every child
            if (typeToReflect.IsArray)
            {
                var arrayType = typeToReflect.GetElementType();
                if (IsPrimitiveValueType(arrayType) == false)
                {
                    var clonedArray = (Array)cloneObject;
                    foreach (var indices in clonedArray.Indices())
                    {
                        clonedArray.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices);
                    }
                }
            }
            // remember the copied reference and it's clone
            visited.Add(originalObject, cloneObject);
            // copy all fields of je original to 
            CopyFields(originalObject, cloneObject, visited, typeToReflect, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            CopyBaseTypePrivateFields(originalObject, cloneObject, visited, typeToReflect);
            return cloneObject;
        }

        private static void CopyBaseTypePrivateFields(object originalObject, object cloneObject, IDictionary<object, object> visited, Type typeToReflect)
        {
            var basetype = typeToReflect.GetTypeInfo().BaseType;
            if (basetype != null)
            {
                CopyBaseTypePrivateFields(originalObject, cloneObject, visited, basetype);
                CopyFields(originalObject, cloneObject, visited, basetype, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
            }
        }

        private static void CopyFields(object originalObject, object cloneObject, IDictionary<object, object> visited, Type typeToReflect, BindingFlags bindingFlags, Func<FieldInfo, bool> filter = null)
        {
            foreach (var fieldInfo in typeToReflect.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false) continue;
                if (IsPrimitiveValueType(fieldInfo.FieldType)) continue;
                fieldInfo.SetValue(cloneObject, InternalCopy(fieldInfo.GetValue(originalObject), visited));
            }
        }
    }
}
