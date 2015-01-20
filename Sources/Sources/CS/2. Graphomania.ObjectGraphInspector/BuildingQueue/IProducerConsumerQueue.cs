namespace Graphomania.ObjectGraphInspector.BuildingQueue
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Graphomania.ObjectGraphInspector.Model;

    public interface IProducerConsumerQueue
    {
        Task Enqueue(ObjectGraphElement element);

        Task<IEnumerable<ObjectGraphElement>> GetElements();
    }
}
