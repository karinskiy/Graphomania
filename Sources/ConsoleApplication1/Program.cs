using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.Serialization;

    using DomainModel.Personal;

    using FizzWare.NBuilder;

    using Graphomania.ObjectGraphInspector;
    using Graphomania.ObjectGraphInspector.ReferenceProvider;
    using Graphomania.ObjectGraphInspector.TraverseStrategies;

    class Program
    {
        static void Main(string[] args)
        {
            var registry = new HashsetObjectRegistry();
            var visitor = new NullVisitor();
            var referenceProvider = new ReflectiveReferenceProvider(new [] {typeof(Employee)});

            IObjectGraphInspector objectGraphInspector = new DepthFirstSingleThreadStrategy(registry, visitor, referenceProvider);

            ISingleObjectBuilder<HierarchySpec<Employee>> hierarchySpec = Builder<HierarchySpec<Employee>>.CreateNew()
                    .With(x => x.AddMethod = (a, b) => a.Subordinates.Add(b))
                    .With(x => x.NamingMethod = (a, b) => a.Name = "Employee " + b)
                    .With(x => x.NumberOfRoots = 1)
                    .With(o => o.Depth = 5)
                    .With(o => o.MinimumChildren = 10)
                    .With(o => o.MaximumChildren = 10);

            var objectGraph = Builder<Employee>.CreateListOfSize(111111).All().BuildHierarchy(hierarchySpec.Build()).First();


            var time = TestSpeed(objectGraphInspector, objectGraph, 10);
            Console.WriteLine(time + " --> " + visitor.counter);

            Console.ReadLine();
        }

        private static TimeSpan TestSpeed(IObjectGraphInspector objectGraphInspector, Employee objectGraph, int runs)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (var i = 0; i < runs; i++)
            {
                objectGraphInspector.Inspect(objectGraph).Wait();
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }

    public class NullVisitor : IObjectGraphVisitor
    {
        public int counter = 0;

        public async Task Visit(object node)
        {
            counter++;
            await Task.Yield();
        }

        public async Task Visit(Reference reference)
        {
            await Task.Yield();
        }
    }
}
