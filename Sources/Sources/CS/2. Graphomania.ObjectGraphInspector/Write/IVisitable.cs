namespace Graphomania.ObjectGraphInspector
{
    public interface IVisitable
    {
        void Accept(IObjectGraphVisitor visitor);
    }
}
