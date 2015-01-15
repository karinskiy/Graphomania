namespace Graphomania.ObjectGraphInspector
{
    using System.Collections.Generic;

    public class DefaultTraversedObjectRegistry : ITraversedObjectRegistry
    {
        private readonly ICollection<object> traversedObjects = new HashSet<object>(); 

        public bool AlreadyTraversed(object graphRoot)
        {
            return this.traversedObjects.Contains(graphRoot);
        }

        public void MarkAsTraversed(object graphRoot)
        {
            this.traversedObjects.Add(graphRoot);
        }
    }
}
