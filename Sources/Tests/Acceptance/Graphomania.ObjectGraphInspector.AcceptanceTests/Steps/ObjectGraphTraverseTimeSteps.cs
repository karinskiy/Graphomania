using System;
using TechTalk.SpecFlow;

namespace Graphomania.ObjectGraphInspector.AcceptanceTests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;

    using DomainModel.Personal;

    using FizzWare.NBuilder;

    using FluentAssertions;

    using Graphomania.ObjectGraphInspector.AcceptanceTests.Mocks;
    using Graphomania.ObjectGraphInspector.TraverseStrategies;

    [Binding]
    public class ObjectGraphTraverseTimeSteps
    {
        private IObjectGraphInspector etalonObjectGraphInspector;
        private IObjectGraphInspector testObjectGraphInspector;

        private readonly ISingleObjectBuilder<HierarchySpec<Employee>> hierarchySpec;
        
        private object objectGraph;


        public ObjectGraphTraverseTimeSteps()
        {
            // Подготовка к генерации фиктивных данных.
            hierarchySpec = Builder<HierarchySpec<Employee>>.CreateNew()
                .With(x => x.AddMethod = (a, b) => a.Subordinates.Add(b))
                .With(x => x.NamingMethod = (a, b) => a.Name = "Employee " + b)
                .With(x => x.NumberOfRoots = 1);
        }

        [Given(@"есть объектный граф с глубиной (.*)")]
        public void ДопустимЕстьОбъектныйГрафСГлубиной(int depth)
        {
            hierarchySpec.With(o => o.Depth = depth);
        }

        [Given(@"минимальным количеством дочерних элементов (.*)")]
        public void ДопустимМинимальнымКоличествомДочернихЭлементов(int min)
        {
            hierarchySpec.With(o => o.MinimumChildren = min);
        }

        [Given(@"максимальным количеством (.*)")]
        public void ДопустимМаксимальнымКоличеством(int max)
        {
            hierarchySpec.With(o => o.MaximumChildren = max);
        }

        [Given(@"количеством элементов в графе (.*)\.")]
        public void ДопустимКоличествомЭлементовВГрафе_(int totalElements)
        {
            objectGraph = Builder<Employee>.CreateListOfSize(totalElements).All().BuildHierarchy(hierarchySpec.Build());
        }

        [When(@"выбрана эталонная стратегия обхода графа ""(.*)"" \(однопоточный алгоритм обхода вглубь\)")]
        public void ЕслиВыбранаЭталоннаяСтратегияОбходаГрафаОднопоточныйАлгоритмОбходаВглубь(string strategyName)
        {
            etalonObjectGraphInspector = SelectStrategy(strategyName);
        }

        [When(@"выбрана другая (.*) обхода графа,")]
        public void ЕслиВыбранаДругаяDepthFirstSingleThreadStrategyОбходаГрафа(string strategyName)
        {
            testObjectGraphInspector = SelectStrategy(strategyName);
        }

        [Then(@"должен быть (.*) обхода относительно эталонного алгоритма\.")]
        public void ТоДолженБытьОбходаОтносительноЭталонногоАлгоритма_(int expectedPercent)
        {
            // 1. Измерение скорости эталонного алгоритма.
            var etalonElapsed = TestSpeed(etalonObjectGraphInspector);

            // 2. Измерение скорости тестируемого алгоритма.
            var testElapsed = TestSpeed(testObjectGraphInspector);

            // 3. Сравнение результата с ожидаемым значением.
            var actualPercent = (etalonElapsed.Milliseconds * 100.0f) / testElapsed.Milliseconds - 100.0f;
            Console.WriteLine("Актуальный прирост скорости {0}%", actualPercent.ToString("##.#"));

            actualPercent.Should().BeGreaterOrEqualTo(expectedPercent);
        }

        private IObjectGraphInspector SelectStrategy(string strategyName)
        {
            Type strategyType;

            try
            {
                strategyType = typeof(ObjectGraphInspectorStrategy).Assembly.GetTypes().Single(o => o.Name == strategyName);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException(string.Format("Тип \"{0}\" не найден!", strategyName));
            }

            //var traversedObjectRegistry = new DefaultTraversedObjectRegistry();
            //var producerConsumerQueue = new ProducerConsumerQueueMock();
            //var objectGraphVisitor = new GraphBuildElementObjectGraphVisitor(producerConsumerQueue, new[] { typeof(Employee) });
            //var referenceProvider = new 
            return (IObjectGraphInspector)Activator.CreateInstance(strategyType, null, null, null);
        }

        private TimeSpan TestSpeed(IObjectGraphInspector instance)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            instance.Inspect(objectGraph);

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
