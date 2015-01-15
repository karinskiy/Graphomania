namespace Graphomania.ObjectGraphInspector
{
    public interface IObjectGraphVisitor
    {
        void Visit(object node);

        void Visit(Reference reference);
    }
}
