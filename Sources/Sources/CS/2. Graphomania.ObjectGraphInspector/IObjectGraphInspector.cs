namespace Graphomania.ObjectGraphInspector
{
    using System.Threading.Tasks;

    public interface IObjectGraphInspector
    {
        Task Inspect(object graphRoot);
    }
}
