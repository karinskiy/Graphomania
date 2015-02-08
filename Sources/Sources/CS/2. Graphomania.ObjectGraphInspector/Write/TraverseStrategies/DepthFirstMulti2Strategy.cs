using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.TraverseStrategies
{
    using System.Collections.Concurrent;

    public class DepthFirstMulti2Strategy : ObjectGraphInspectorStrategy
    {
        public DepthFirstMulti2Strategy(ITraversedObjectRegistry traversedObjectRegistry, IObjectGraphVisitor graphVisitor, IReferenceProvider referenceProvider)
            : base(traversedObjectRegistry, graphVisitor, referenceProvider)
        {
        }

        public override void Inspect(object graphRoot)
        {
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

    public static class AsyncExtension
    {
        public static async Task<IEnumerable<T>> TraverseAsync<T>(this IEnumerable<T> source, Func<T, Task<IEnumerable<T>>> childSelector)
        {
            var results = new ConcurrentBag<T>();

            Func<T, Task> foo = null;

            foo = async next =>
            {
                results.Add(next);
                var children = await childSelector(next);
                await Task.WhenAll(children.Select(child => foo(child)));
            };

            await Task.WhenAll(source.Select(child => foo(child)));
            return results;
        }
    }
}
