namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;
    using System.Threading.Tasks;

    public class DepthFirstSingleThreadStrategy : ObjectGraphInspectorStrategy
    {
        private readonly object objectLock = new object();

        public DepthFirstSingleThreadStrategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
            : base(traversedObjectRegistry, graphVisitor, referenceProvider)
        {
        }

        public override async Task Inspect(object graphRoot)
        {
            if (AlreadyTraversed(graphRoot))
            {
                return;
            }

            MarkAsTraversed(graphRoot);

            await graphVisitor.Visit(graphRoot);

            foreach (var reference in referenceProvider.GetReferences(graphRoot))
            {
                await graphVisitor.Visit(reference);
                await Inspect(reference.To);
            }
        }

        private bool AlreadyTraversed(object graphRoot)
        {
            return traversedObjectRegistry.AlreadyTraversed(graphRoot);
        }

        private void MarkAsTraversed(object graphRoot)
        {
            lock (objectLock)
            {
                traversedObjectRegistry.MarkAsTraversed(graphRoot);
            }
        }
    }
}
