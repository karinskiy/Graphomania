namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;

    public class DepthFirstSingleThreadStrategy : ObjectGraphInspectorStrategy
    {
        public override void Inspect(object graphRoot)
        {
            Thread.Sleep(1000);
        }
    }
}
