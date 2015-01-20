using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphomania.ObjectGraphInspector.AcceptanceTests.Tags
{
    using BoDi;

    using Graphomania.ObjectGraphInspector.BuildingQueue;
    using Graphomania.ObjectGraphInspector.Model;

    using Moq;

    using TechTalk.SpecFlow;

    [Binding]
    public class ComponentsRegistration
    {
        private readonly IObjectContainer objectContainer;

        public ComponentsRegistration(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        #region Real Components

        [BeforeScenario]
        public void RegisterComponents()
        {
        }

        [AfterScenario]
        public void Unregister()
        {
        }

        #endregion

        #region Mock Components

        [BeforeScenario("Имитация")]
        public void RegisterMockComponents()
        {
            // Имитация
            var objectGraphInspector = new Mock<IObjectGraphInspector>();
            objectGraphInspector.Setup(o => o.Inspect(It.IsAny<object>()));

            // Регистрация
            objectContainer.RegisterInstanceAs(objectGraphInspector.Object);


            // Подготовка фиктивных данных
            var expectedElements = new ObjectGraphElement[]
            {
                new NodeElement("Company", "1"), 
                new NodeElement("Department", "2"), 
                new NodeElement("Department", "3"), 
                new RelationElement("1", "Departments", "2"), 
                new RelationElement("1", "Departments", "3"),                 
            };

            // Имитация
            var producerConsumerQueue = new Mock<IProducerConsumerQueue>();
            producerConsumerQueue.Setup(o => o.GetElements()).Returns(() => Task.Run<IEnumerable<ObjectGraphElement>>(() => expectedElements));

            // Регистрация
            objectContainer.RegisterInstanceAs(producerConsumerQueue.Object);
        }

        #endregion
    }
}
