namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;

    public class DepthFirstSingleThreadStrategy : ObjectGraphInspectorStrategy
    {
        public DepthFirstSingleThreadStrategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
            : base(traversedObjectRegistry, graphVisitor, referenceProvider)
        {
        }

        public override void Inspect(object graphRoot)
        {
            if (this.AlreadyTraversed(graphRoot))
            {
                return;
            }

            this.MarkAsTraversed(graphRoot);

            this.graphVisitor.Visit(graphRoot);

            foreach (var reference in this.referenceProvider.GetReferences(graphRoot))
            {
                this.graphVisitor.Visit(reference);
                this.Inspect(reference.To);
            }
        }

        private bool AlreadyTraversed(object graphRoot)
        {
            return this.traversedObjectRegistry.AlreadyTraversed(graphRoot);
        }

        private void MarkAsTraversed(object graphRoot)
        {
            this.traversedObjectRegistry.MarkAsTraversed(graphRoot);
        }
    }
}
