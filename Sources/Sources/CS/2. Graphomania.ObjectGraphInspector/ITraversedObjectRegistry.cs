namespace Graphomania.ObjectGraphInspector
{
    public interface ITraversedObjectRegistry
    {
        bool AlreadyTraversed(object graphRoot);

        void MarkAsTraversed(object graphRoot);
    }
}
