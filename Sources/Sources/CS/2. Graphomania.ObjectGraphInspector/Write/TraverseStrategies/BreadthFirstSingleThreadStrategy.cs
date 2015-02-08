namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class BreadthFirstSingleThreadStrategy : ObjectGraphInspectorStrategy
    {
        public BreadthFirstSingleThreadStrategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
            : base(traversedObjectRegistry, graphVisitor, referenceProvider)
        {
        }

        public override void Inspect(object graphRoot)
        {
            var nodeQueue = new Queue<object>();

            nodeQueue.Enqueue(graphRoot);

            while (nodeQueue.Any())
            {
                var node = nodeQueue.Dequeue();
                
                foreach (var reference in referenceProvider.GetReferences(node))
                {
                    var child = reference.To;

                    if (AlreadyTraversed(child))
                    {
                        continue;
                    }

                    graphVisitor.Visit(child);
                    MarkAsTraversed(child);

                    nodeQueue.Enqueue(child);
                }
            }
        }

        private bool AlreadyTraversed(object graphRoot)
        {
            return traversedObjectRegistry.AlreadyTraversed(graphRoot);
        }

        private void MarkAsTraversed(object graphRoot)
        {
            //lock (objectLock)
            {
                traversedObjectRegistry.MarkAsTraversed(graphRoot);
            }
        }
    }
}
