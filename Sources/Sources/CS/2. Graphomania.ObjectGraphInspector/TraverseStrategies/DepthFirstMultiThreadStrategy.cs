namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
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
            if (AlreadyTraversed(graphRoot))
            {
                return;
            }

            MarkAsTraversed(graphRoot);

            graphVisitor.Visit(graphRoot);

            var tasks = new List<Task>();
            foreach (var reference in referenceProvider.GetReferences(graphRoot))
            {
                var child = reference.To;
                tasks.Add(Task.Run(() => Inspect(child)));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private bool AlreadyTraversed(object graphRoot)
        {
            return traversedObjectRegistry.AlreadyTraversed(graphRoot);
        }

        private void MarkAsTraversed(object graphRoot)
        {
            lock (this)
            {
                traversedObjectRegistry.MarkAsTraversed(graphRoot);
            }
        }
    }
}
