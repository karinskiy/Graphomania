using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.UnitTests
{
    using DomainModel.Personal;

    using Graphomania.ObjectGraphInspector.ReferenceProvider;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReferenceProviderTests
    {
        [TestMethod]
        public void aaa()
        {
            // arrange
            var domainTypes = new[] { typeof(Employee) };
            IReferenceProvider referenceProvider = new ReflectiveReferenceProvider(domainTypes);
            
            var objectGraph = new Employee
            {
                ID = "1",
                Subordinates = new[]
				{
					new Employee { ID = "2" },
					new Employee { ID = "3" },
				}
            };
            
            // act
            var references = referenceProvider.GetReferences(objectGraph);

            // assert
            references.ShouldAllBeEquivalentTo(new []
            {
                new Reference("Subordinates", objectGraph, objectGraph.Subordinates.ElementAt(0)),
                new Reference("Subordinates", objectGraph, objectGraph.Subordinates.ElementAt(1)),
            }, polymorphicItems: true);
        }
    }
}
