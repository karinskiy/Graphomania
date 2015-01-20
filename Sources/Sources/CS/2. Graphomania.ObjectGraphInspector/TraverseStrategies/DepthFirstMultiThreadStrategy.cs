namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Threading;

    public class DepthFirstMultiThreadStrategy : ObjectGraphInspectorStrategy
    {
        public override void Inspect(object graphRoot)
        {
            Thread.Sleep(100);
        }
    }
}
