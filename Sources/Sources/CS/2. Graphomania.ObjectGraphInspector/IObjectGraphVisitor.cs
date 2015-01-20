namespace Graphomania.ObjectGraphInspector
{
    using System.Threading.Tasks;

    public interface IObjectGraphVisitor
    {
        Task Visit(object node);

        Task Visit(Reference reference);
    }
}
