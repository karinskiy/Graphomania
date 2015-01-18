using System;
using TechTalk.SpecFlow;

namespace Graphomania.ObjectGraphInspector.AcceptanceTests
{
    using System.Diagnostics;

    using DomainModel.Personal;

    using FizzWare.NBuilder;

    [Binding]
    public class ObjectGraphTraverseTimeSteps
    {
        private readonly IObjectGraphInspector objectGraphInspector;

        private readonly ISingleObjectBuilder<HierarchySpec<Employee>> hierarchySpec;
        
        private object objectGraph;
        private TimeSpan etalonRunSpeed;


        public ObjectGraphTraverseTimeSteps(IObjectGraphInspector objectGraphInspector)
        {
            this.objectGraphInspector = objectGraphInspector;

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

        [Given(@"максимальным количеством (.*)\.")]
        public void ДопустимМаксимальнымКоличеством_(int max)
        {
            hierarchySpec.With(o => o.MaximumChildren = max);
        }

        [When(@"выбрана (.*) обхода графа \(для (.*) элементов\),")]
        public void ЕслиВыбранаDepthFirstSingleThreadStrategyОбходаГрафа(string strategy, int elementsTotal)
        {
            objectGraph = Builder<Employee>.CreateListOfSize(elementsTotal).All().BuildHierarchy(hierarchySpec.Build());
        }

        [Then(@"должен быть (.*) обхода относительно эталонного \(однопоточный алгоритм обхода вглубь\)\.")]
        public void ТоДолженБыть_ОбходаОтносительноЭталонногоОднопоточныйАлгоритмОбходаВглубь_(string percent)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            objectGraphInspector.Inspect(objectGraph);

            stopwatch.Stop();


        }
    }
}
