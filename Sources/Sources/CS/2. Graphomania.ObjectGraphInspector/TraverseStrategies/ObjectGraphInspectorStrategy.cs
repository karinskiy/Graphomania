namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    public abstract class ObjectGraphInspectorStrategy : IObjectGraphInspector
    {
        public abstract void Inspect(object graphRoot);
    }
}
