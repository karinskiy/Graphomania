namespace Graphomania.ObjectGraphInspector
{
    using System.Collections.Generic;

    public interface IReferenceProvider
    {
        IEnumerable<Reference> GetReferences(object graphRoot);
    }
}
