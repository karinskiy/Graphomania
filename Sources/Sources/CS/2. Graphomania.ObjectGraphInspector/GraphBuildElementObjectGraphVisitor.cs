namespace Graphomania.ObjectGraphInspector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Graphomania.ObjectGraphInspector.BuildingQueue;
    using Graphomania.ObjectGraphInspector.Model;

    public class GraphBuildElementObjectGraphVisitor : IObjectGraphVisitor
    {
        private readonly IProducerConsumerQueue producerConsumerQueue;
        private readonly IEnumerable<Type> domainTypes;

        public GraphBuildElementObjectGraphVisitor(IProducerConsumerQueue producerConsumerQueue, IEnumerable<Type> domainTypes)
        {
            this.producerConsumerQueue = producerConsumerQueue;
            this.domainTypes = domainTypes;
        }

        public async Task Visit(object node)
        {
            // Построение описателя узла графа.
            var nodeElement = new NodeElement("", "");

            var publicProperties = node.GetType().GetProperties().Where(p => p.IsPlainProperty(this.domainTypes));
            foreach (var property in publicProperties)
            {
                var value = property.GetValue(node);
                nodeElement.AddProperty(property.Name, value);
            }

            // Отправка в очередь.
            await producerConsumerQueue.Enqueue(nodeElement);
        }

        public async Task Visit(Reference reference)
        {
            throw new NotImplementedException();
        }
    }
}
