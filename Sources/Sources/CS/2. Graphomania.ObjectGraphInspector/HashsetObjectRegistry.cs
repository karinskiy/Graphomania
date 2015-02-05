namespace Graphomania.ObjectGraphInspector
{
    using System.Collections.Generic;

    public class HashsetObjectRegistry : ITraversedObjectRegistry
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

        public void Clear()
        {
            traversedObjects.Clear();
        }
    }
}
