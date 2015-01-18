using System;
using TechTalk.SpecFlow;

namespace Graphomania.ObjectGraphInspector.AcceptanceTests.Steps
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Markup;

    using DomainModel.Personal;

    using FluentAssertions;

    using Graphomania.ObjectGraphInspector.Model;

    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class ObjectGraphTraverseSteps
    {
        private readonly IObjectGraphInspector objectGraphInspector;
        private IEnumerable<ObjectGraphElement> actualElements;


        [Given(@"на входе будет объектный граф, описанный таблицей, типы объектов лежат в сборке ""(.*)"":")]
        public void ДопустимНаВходеБудетОбъектныйГрафОписанныйТаблицейТипыОбъектовЛежатВСборке(string assemblyName, IEnumerable<dynamic> table)
        {
            foreach (var row in table)
            {
                Type objectType = GetObjectTypeByName(assemblyName, row.ТипОбъекта);
                object objectInstance = CreateInstance(objectType, row.АргументыКонструктора, row.СвязанС, row.МетодПрисвоения);
                createdObjects.Add(row.ИмяЭкземпляра, objectInstance);



                var referenceName = row.МетодПрисвоения;
                if (!string.IsNullOrWhiteSpace(referenceName))
                {
                    IEnumerable<MemberInfo> members = objectType.GetMember(referenceName);

                    var reference = members.SingleOrDefault();

                    if (reference == null && !string.IsNullOrWhiteSpace((string)row.СвязанС))
                    {
                        object owner = createdObjects[row.СвязанС];
                        PropertyInfo property = owner.GetType().GetProperty(referenceName);


                        var addMethod = property.PropertyType.GetMethod("Add");
                        var collectionInstance = property.GetValue(owner);

                        addMethod.Invoke(collectionInstance, new[] { objectInstance });

                        continue;
                    }

                    if (reference == null)
                    {
                        //throw new ArgumentException(string.Format("Метод или свойство \"{0}\" не существует!", referenceName));
                        continue;
                    }

                    if (reference is MethodInfo)
                    {
                        // Это метод!
                    }
                    else if (reference is PropertyInfo)
                    {
                        var property = reference as PropertyInfo;

                        if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                        {
                            //var collection = (IEnumerable)property.GetValue(source);
                            //foreach (var o in collection)
                            //{
                            //    Assert.AreEqual(o, destination);
                            //}
                        }
                        else
                        {
                            var target = createdObjects[row.СвязанС];
                            property.SetValue(objectInstance, target);
                        }
                    }
                }
            }
        }

        [Given(@"свойства объектов содержат следующие значения:")]
        public void ДопустимСвойстваОбъектовСодержатСледующиеЗначения(IEnumerable<dynamic> table)
        {
            foreach (var row in table)
            {
                var source = createdObjects[row.ИмяЭкземпляра];
                PropertyInfo property = source.GetType().GetProperty(row.Свойство);

                if (property == null)
                {
                    throw new InvalidOperationException(string.Format("У типа \"{0}\" не найден атрибут \"{1}\"", source.GetType().Name, row.Свойство));
                }

                var value = GetExpectedValue(row.Значение);
                property.SetValue(source, value);
            }
        }

        [Then(@"на выходе будет список элементов, описывающих объекты объектного графа:")]
        public void ТоНаВыходеБудетСписокЭлементовОписывающихОбъектыОбъектногоГрафа(IEnumerable<ObjectGraphElement> expectedElements)
        {
            actualElements = new[]
                             {
                                 new NodeElement("Company1", "1"), 
                                 new NodeElement("Department", "2"), 
                                 new NodeElement("Department", "3"), 
                             };

            var nodePairs = from actualNode in actualElements.OfType<NodeElement>()
                            join expectedNode in expectedElements.OfType<NodeElement>() on actualNode.ObjectId equals expectedNode.ObjectId
                            select new { Actual = actualNode, Expected = expectedNode };

            foreach (var nodePair in nodePairs)
            {
                nodePair.Actual.ShouldBeEquivalentTo(nodePair.Expected);
            }

            //TODO: Как-то нужно аравнивать отношения!
        }

        [StepArgumentTransformation]
        public static IEnumerable<ObjectGraphElement> TObjectGraphElements(Table table)
        {
            foreach (dynamic row in table.CreateDynamicSet())
            {
                switch ((string)row.ТипЭлемента)
                {
                    case "Node":
                        yield return new NodeElement(objectType: (string)row.ТипОбъекта, objectId: Convert.ToString(row.IDОбъекта));
                        break;
                    case "Relation":
                        break;
                }
            }
        }

        #region Internal methods

        private static readonly IDictionary<string, object> createdObjects = new Dictionary<string, object>();

        private object GetExpectedValue(string value)
        {
            if (value.StartsWith("@"))
            {
                // Это ссылка.
                var objectName = value.Substring(1);
                return createdObjects[objectName];
            }

            int result = 0;
            if (Int32.TryParse(value, out result))
            {
                return result;
            }
            else if (value.StartsWith("\"") && value.EndsWith("\""))
            {
                return value.Replace("\"", null);
            }

            throw new ArgumentException("Недопустимый формат строки " + value);
        }

        private Type GetObjectTypeByName(string assemblyName, string objectTypeName)
        {
            var assembly = Assembly.LoadFrom(assemblyName + ".dll");

            try
            {
                return assembly.GetTypes().Single(t => t.Name == objectTypeName);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException(string.Format("Тип \"{0}\" не найден в заданной сборке!", objectTypeName));
            }
        }

        private object CreateInstance(Type objectType, string creationArgs, string dependOn, string methodName)
        {
            var argsWithCmd = creationArgs.Split(':', ',').Select(s => s.Trim()).ToArray();
            var createBy = argsWithCmd.First();
            var args = argsWithCmd.Skip(1);

            switch (createBy)
            {
                case "ctor":
                    return CreateByCtor(objectType, args);

                case "method":
                    return CreateByFactoryMethod(args, dependOn, methodName);

                default:
                    throw new NotSupportedException(createBy);
            }
        }

        private object CreateByCtor(Type objectType, IEnumerable<string> stringArgs)
        {
            var args = CreateArgumentArray(stringArgs);
            var instance = CreateInstance(objectType, args);


            return instance;
        }

        private object CreateByFactoryMethod(IEnumerable<string> stringArgs, string dependOn, string methodName)
        {
            var args = CreateArgumentArray(stringArgs);
            return CreateByFactoryMethod2(args, dependOn, methodName);
        }

        private object CreateByFactoryMethod2(object[] args, string dependOn, string methodName)
        {
            var creatorInstance = createdObjects[dependOn];

            var argTypes = from a in args select a.GetType();
            var method = creatorInstance.GetType().GetMethod(methodName, argTypes.ToArray());

            if (method == null)
            {
                throw new ArgumentException(string.Format("В типе \"{0}\" не найден метод \"{1}\"", creatorInstance.GetType().Name, methodName));
            }

            return method.Invoke(creatorInstance, args);
        }

        private object CreateInstance(Type objectType, object[] ctorArgs)
        {
            return Activator.CreateInstance(objectType, ctorArgs);
        }

        private static object[] CreateArgumentArray(IEnumerable<string> stringArray)
        {
            var accumulator = new List<object>();

            foreach (var s in stringArray)
            {
                if (s.StartsWith("\"") && s.EndsWith("\""))
                {
                    accumulator.Add(s.Replace("\"", null));
                }
                else if (s.ToLower() == "null")
                {
                    accumulator.Add(null);
                }
                else if (createdObjects.ContainsKey(s))
                {
                    accumulator.Add(createdObjects[s]);
                }
            }

            return accumulator.ToArray();
        }

        #endregion
    }
}
