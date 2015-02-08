namespace Graphomania.ObjectGraphInspector
{
    using System.Threading.Tasks;

    public interface IObjectGraphInspector
    {
        void Inspect(object graphRoot);
    }
}
