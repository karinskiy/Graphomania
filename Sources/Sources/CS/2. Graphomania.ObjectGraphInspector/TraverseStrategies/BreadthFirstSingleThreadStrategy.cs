namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;

    public class BreadthFirstSingleThreadStrategy : ObjectGraphInspectorStrategy
    {
        public override void Inspect(object graphRoot)
        {
            Thread.Sleep(850);
        }
    }
}
