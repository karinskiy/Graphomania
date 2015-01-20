namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading.Tasks;

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

        public abstract Task Inspect(object graphRoot);
    }
}
