namespace Graphomania.ObjectGraphInspector.BuildingQueue
{
    using System.Collections.Generic;

    using Graphomania.ObjectGraphInspector.Model;

    public interface IProducerConsumerQueue
    {
        void Enqueue(ObjectGraphElement element);

        IEnumerable<ObjectGraphElement> GetElements();
    }
}
