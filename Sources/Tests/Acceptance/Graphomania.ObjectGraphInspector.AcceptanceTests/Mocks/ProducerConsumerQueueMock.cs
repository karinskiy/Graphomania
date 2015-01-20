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
        public async Task Enqueue(ObjectGraphElement element)
        {
        }

        public async Task<IEnumerable<ObjectGraphElement>> GetElements()
        {
            throw new NotImplementedException();
        }
    }
}
