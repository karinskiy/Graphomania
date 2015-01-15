namespace Graphomania.ObjectGraphInspector
{
    public class SimpleObjectGraphInspector : IObjectGraphInspector
    {
        private readonly ITraversedObjectRegistry traversedObjectRegistry;
        private readonly IObjectGraphVisitor graphVisitor;
        private readonly IReferenceProvider referenceProvider;

        public SimpleObjectGraphInspector(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
        {
            this.traversedObjectRegistry = traversedObjectRegistry;
            this.graphVisitor = graphVisitor;
            this.referenceProvider = referenceProvider;
        }

        public void Inspect(object graphRoot)
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
