using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.AcceptanceTests.Mocks
{
    using Graphomania.ObjectGraphInspector.BuildingQueue;
    using Graphomania.ObjectGraphInspector.Model;

    internal class ProducerConsumerQueueMock : IProducerConsumerQueue
    {
        public void Enqueue(ObjectGraphElement element)
        {
        }

        public IEnumerable<ObjectGraphElement> GetElements()
        {
            throw new NotImplementedException();
        }
    }
}
