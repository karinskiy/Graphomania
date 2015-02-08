using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.ReferenceProvider
{
    using System.Collections;
    using System.Reflection;

    public class ReflectiveReferenceProvider : IReferenceProvider
    {
        private readonly IEnumerable<Type> navigableTypes;

        public ReflectiveReferenceProvider(IEnumerable<Type> navigableTypes)
        {
            this.navigableTypes = navigableTypes;
        }

        public IEnumerable<Reference> GetReferences(object graphRoot)
        {
            // 1. Получить список всех навигационных свойств.
            var navigationProperties = GetNavigationProperties(graphRoot);

            // 2. Создать объект Reference из каждого такого свойства.
            return from property in navigationProperties
                   from reference in BuildReferences(property, graphRoot)
                   select reference;
        }

        public IEnumerable<PropertyInfo> GetNavigationProperties(object graphRoot)
        {
            var objectType = graphRoot.GetType();

            var properties = from p in objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                             where p.CanRead && p.IsNavigationProperty(navigableTypes)
                             select p;

            return properties;
        }

        private IEnumerable<Reference> BuildReferences(PropertyInfo property, object source)
        {
            if (property.IsCollectionProperty(navigableTypes))
            {
                // Если свойство - это коллекция, то построить и вернуть множество ссылок.
                var collection = (IEnumerable)property.GetValue(source);

                foreach (var destination in collection)
                {
                    if (destination != null)
                    {
                        yield return new Reference(property.Name, from: source, to: destination);
                    }
                }
            }
            else
            {
                // Иначе это одиночное навигационное свойство.
                var destination = property.GetValue(source);

                if (destination != null)
                {
                    yield return new Reference(property.Name, from: source, to: destination);   
                }
            }
        }
    }
}
