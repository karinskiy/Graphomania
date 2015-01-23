namespace Graphomania.ObjectGraphInspector.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;

    using DomainModel.Personal;

    using FluentAssertions;

    using Graphomania.ObjectGraphInspector.BuildingQueue;
    using Graphomania.ObjectGraphInspector.Model;
    using Graphomania.ObjectGraphInspector.TraverseStrategies;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ObjectGraphInspectorTests
    {
        [TestMethod]
        public async Task TraverseSimpleGraph()
        {
            // arrange
            var objectGraph = new Employee
            {
                ID = "1",
                Subordinates = new[]
				{
					new Employee { ID = "2" },
					new Employee { ID = "3" },
				}
            };

            var traversedRegistry = new HashsetObjectRegistry();

            var referenceProvider = new ReferenceProviderStub(objectGraph, objectGraph.Subordinates.ElementAt(0), objectGraph.Subordinates.ElementAt(1));

            var graphElements = new List<ObjectGraphElement>();
            var graphVisitor = new ObjectElementVisitorMock(graphElements);

            var objectGraphInspector = new DepthFirstSingleThreadStrategy(traversedRegistry, graphVisitor, referenceProvider);

            // act
            objectGraphInspector.Inspect(objectGraph);

            // assert
            graphElements
                .ShouldAllBeEquivalentTo(new ObjectGraphElement[]
                {
                    new NodeElement("Employee", "1"), 
                    new NodeElement("Employee", "2"), 
                    new RelationElement("1", "Subordinates", "2"), 
                    new NodeElement("Employee", "3"), 
                    new RelationElement("1", "Subordinates", "3"), 
                }, polymorphicItems: true);
        }
    }

    public static class AssertionExtension
    {
        public static void ShouldAllBeEquivalentTo<T>(this IEnumerable<T> subject, IEnumerable expectation, bool polymorphicItems = false, string because = "", params object[] reasonArgs)
        {
            subject.ShouldAllBeEquivalentTo(expectation, opt => opt.IncludingAllRuntimeProperties(), because, reasonArgs);
        }
    }

    public class ReferenceProviderStub : IReferenceProvider
    {
        private readonly Employee[] employees;

        public ReferenceProviderStub(params Employee[] employees)
        {
            this.employees = employees;
        }

        public IEnumerable<Reference> GetReferences(object graphRoot)
        {
            var o = (Employee)graphRoot;
            if (o.ID == "1")
            {
                yield return new Reference("Subordinates", employees[0], employees[1]);
                yield return new Reference("Subordinates", employees[0], employees[2]);
            }
        }
    }

    public class ObjectElementVisitorMock : IObjectGraphVisitor
    {
        private readonly ICollection<ObjectGraphElement> graphElements;

        public ObjectElementVisitorMock(ICollection<ObjectGraphElement> graphElements)
        {
            this.graphElements = graphElements;
        }

        public void Visit(object node)
        {
            //await Task.Run(() => graphElements.Add(new NodeElement("Employee", ((Employee)node).ID)));
        }

        public void Visit(Reference reference)
        {
            //await Task.Run(() => graphElements.Add(new RelationElement(((Employee)reference.From).ID, reference.Name, ((Employee)reference.To).ID)));
        }
    }
}
