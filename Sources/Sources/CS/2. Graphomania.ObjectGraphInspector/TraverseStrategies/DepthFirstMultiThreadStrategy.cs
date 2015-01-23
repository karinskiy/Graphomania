namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;
    using System.Threading.Tasks;

    public class DepthFirstMultiThreadStrategy : ObjectGraphInspectorStrategy
    {
        public DepthFirstMultiThreadStrategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
            : base(traversedObjectRegistry, graphVisitor, referenceProvider)
        {
        }

        public override void Inspect(object graphRoot)
        {
            Thread.Sleep(100);
        }
    }
}
