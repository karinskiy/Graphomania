namespace Graphomania.ObjectGraphInspector.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
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

            var traversedRegistry = new Mock<ITraversedObjectRegistry>().Object;

            Mock.Get(traversedRegistry)
                .Setup(o => o.AlreadyTraversed(It.IsAny<object>()))
                .Returns(false);

            
            var referenceProvider = new Mock<IReferenceProvider>().Object;

			Mock.Get(referenceProvider)
				.Setup(o => o.GetReferences(objectGraph))
				.Returns(() => new [] 
                { 
                    new Reference("Subordinates", objectGraph, objectGraph.Subordinates.ElementAt(0)),
					new Reference("Subordinates", objectGraph, objectGraph.Subordinates.ElementAt(1)),
				});


            var graphVisitor = new Mock<IObjectGraphVisitor>().Object;

            var graphElements = new List<ObjectGraphElement>();

			Mock.Get(graphVisitor)
				.Setup(o => o.Visit(It.IsAny<object>()))
				.Callback<object>(o => graphElements.Add(new NodeElement("Employee", "1")));

            Mock.Get(graphVisitor)
                .Setup(o => o.Visit(It.IsAny<Reference>()))
                .Callback<Reference>(o => graphElements.Add(new RelationElement("1", "Refefe", "2")));

            var objectGraphInspector = new DepthFirstSingleThreadStrategy(traversedRegistry, graphVisitor, referenceProvider);

            // act
            await objectGraphInspector.Inspect(objectGraph);
            
            // assert
            graphElements
                .ShouldBeEquivalentTo(new ObjectGraphElement[]
                {
                    new NodeElement("Employee", "1"), 
                    new NodeElement("Employee", "2"), 
                    new RelationElement("1", "Subordinates", "2"), 
                    new NodeElement("Employee", "3"), 
                    new RelationElement("1", "Subordinates", "3"), 
                });

            //(await elementQueue.GetElements())
            //    .ShouldBeEquivalentTo(new ObjectGraphElement[]
            //    {
            //        new NodeElement("Employee", "1"), 
            //        new NodeElement("Employee", "2"), 
            //        new RelationElement("1", "Subordinates", "2"), 
            //        new NodeElement("Employee", "3"), 
            //        new RelationElement("1", "Subordinates", "3"), 
            //    });
        }
    }
}
