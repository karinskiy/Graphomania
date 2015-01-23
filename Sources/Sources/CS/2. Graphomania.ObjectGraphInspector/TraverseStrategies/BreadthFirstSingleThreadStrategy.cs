namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;
    using System.Threading.Tasks;

    public class BreadthFirstSingleThreadStrategy : ObjectGraphInspectorStrategy
    {
        public BreadthFirstSingleThreadStrategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
            : base(traversedObjectRegistry, graphVisitor, referenceProvider)
        {
        }

        public override void Inspect(object graphRoot)
        {
            Thread.Sleep(850);
        }
    }
}
