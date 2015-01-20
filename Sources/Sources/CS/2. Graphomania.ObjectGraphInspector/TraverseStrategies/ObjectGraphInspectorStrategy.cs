namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    public abstract class ObjectGraphInspectorStrategy : IObjectGraphInspector
    {
        protected readonly ITraversedObjectRegistry traversedObjectRegistry;
        protected readonly IObjectGraphVisitor graphVisitor;
        protected readonly IReferenceProvider referenceProvider;

        protected ObjectGraphInspectorStrategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
        {
            this.traversedObjectRegistry = traversedObjectRegistry;
            this.graphVisitor = graphVisitor;
            this.referenceProvider = referenceProvider;
        }

        public abstract void Inspect(object graphRoot);
    }
}
