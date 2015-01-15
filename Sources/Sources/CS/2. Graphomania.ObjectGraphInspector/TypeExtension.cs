namespace Graphomania.ObjectGraphInspector
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class TypeExtension
    {
        public static Type GetTypeOfCollectionElement(this object instance)
        {
            var collection = instance as IEnumerable;

            if (collection == null)
            {
                return null;
            }

            var type = collection.GetType();
            var ienum = type.GetInterface(typeof(IEnumerable<>).Name);
            return ienum != null ? ienum.GetGenericArguments()[0] : null;
        }

        public static bool IsNavigationProperty(this PropertyInfo propertyInfo, IEnumerable<Type> domainTypes)
        {
            var itemType = GetCollectionItemType(propertyInfo.PropertyType);
            return domainTypes.Contains(itemType);
        }

        private static Type GetCollectionItemType(Type type)
        {
            // Это массив?
            if (typeof(Array).IsAssignableFrom(type))
            {
                return type.GetElementType();
            }

            // Это IEnumerable<> ?
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetGenericArguments()[0];
            }

            // Это наследник IEnumerable<T> ?
            var enumType = type.GetInterfaces()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Select(t => t.GenericTypeArguments[0]).FirstOrDefault();

            return enumType ?? type;
        }

        public static bool IsPlainProperty(this PropertyInfo propertyInfo, IEnumerable<Type> domainTypes)
        {
            return !IsNavigationProperty(propertyInfo, domainTypes);
        }
    }
}
