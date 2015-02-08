namespace Graphomania.ObjectGraphInspector
{
    using System.Threading.Tasks;

    public interface IObjectGraphVisitor
    {
        void Visit(object node);

        void Visit(Reference reference);
    }
}
