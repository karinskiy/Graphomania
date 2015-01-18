﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Graphomania.ObjectGraphInspector.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ObjectGraphTraverseFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ObjectGraphTraverse.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Object graph traverse", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, new string[] {
                        "Имитация"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Object graph traverse")))
            {
                Graphomania.ObjectGraphInspector.AcceptanceTests.ObjectGraphTraverseFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Обход графа и получение плоского списка его элементов.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Object graph traverse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Имитация")]
        public virtual void ОбходГрафаИПолучениеПлоскогоСпискаЕгоЭлементов_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Обход графа и получение плоского списка его элементов.", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Тип объекта",
                        "Аргументы конструктора",
                        "Имя экземпляра",
                        "Связан с",
                        "Метод присвоения"});
            table1.AddRow(new string[] {
                        "Company",
                        "ctor:",
                        "company1",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "Department",
                        "ctor:",
                        "department1",
                        "company1",
                        "Departments"});
            table1.AddRow(new string[] {
                        "Department",
                        "ctor:",
                        "department2",
                        "company1",
                        "Departments"});
#line 8
 testRunner.Given("на входе будет объектный граф, описанный таблицей, типы объектов лежат в сборке \"" +
                    "DomainModel\":", ((string)(null)), table1, "Допустим ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Имя экземпляра",
                        "Свойство",
                        "Значение"});
            table2.AddRow(new string[] {
                        "company1",
                        "ID",
                        "1"});
            table2.AddRow(new string[] {
                        "company1",
                        "Title",
                        "\"ИГИТ\""});
            table2.AddRow(new string[] {
                        "department1",
                        "ID",
                        "2"});
            table2.AddRow(new string[] {
                        "department1",
                        "Title",
                        "\"Отдел разработки\""});
            table2.AddRow(new string[] {
                        "department2",
                        "ID",
                        "3"});
            table2.AddRow(new string[] {
                        "department2",
                        "Title",
                        "\"Отдел 3d-моделирования\""});
#line 13
 testRunner.And("свойства объектов содержат следующие значения:", ((string)(null)), table2, "К тому же ");
#line 22
 testRunner.When("выполнить обход графа,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Если ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Тип элемента",
                        "Тип объекта",
                        "ID объекта",
                        "ID начала",
                        "ID конца",
                        "Имя связи",
                        "Содержимое атрибутов объекта в JSON"});
            table3.AddRow(new string[] {
                        "Node",
                        "Company",
                        "1",
                        "",
                        "",
                        "",
                        "{ Name: \"Теплосеть 1\", Description: \"Тепловая сеть\" }"});
            table3.AddRow(new string[] {
                        "Node",
                        "Department",
                        "2",
                        "",
                        "",
                        "",
                        "{ Name: \"Теплосеть 1\", Description: \"Тепловая сеть\" }"});
            table3.AddRow(new string[] {
                        "Node",
                        "Department",
                        "3",
                        "",
                        "",
                        "",
                        "{ Name: \"Теплосеть 1\", Description: \"Тепловая сеть\" }"});
            table3.AddRow(new string[] {
                        "Relation",
                        "",
                        "",
                        "1",
                        "2",
                        "Departments",
                        ""});
            table3.AddRow(new string[] {
                        "Relation",
                        "",
                        "",
                        "1",
                        "3",
                        "Departments",
                        ""});
#line 24
 testRunner.Then("на выходе будет список элементов, описывающих объекты объектного графа:", ((string)(null)), table3, "То ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void СравнениеРазличныхСтратегийОбходаОбъектногоГрафа_(string стратегия, string приростСкорости, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сравнение различных стратегий обхода объектного графа.", exampleTags);
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("есть объектный граф с глубиной 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Допустим ");
#line 36
 testRunner.And("минимальным количеством дочерних элементов 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 37
 testRunner.And("максимальным количеством 10.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 39
 testRunner.When(string.Format("выбрана {0} обхода графа (для 300 элементов),", стратегия), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Если ");
#line 40
 testRunner.Then(string.Format("должен быть {0} обхода относительно эталонного (однопоточный алгоритм обхода вглу" +
                        "бь).", приростСкорости), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "То ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Сравнение различных стратегий обхода объектного графа.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Object graph traverse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Имитация")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "DepthFirstSingleThreadStrategy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Стратегия", "DepthFirstSingleThreadStrategy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:прирост скорости", "0")]
        public virtual void СравнениеРазличныхСтратегийОбходаОбъектногоГрафа__DepthFirstSingleThreadStrategy()
        {
            this.СравнениеРазличныхСтратегийОбходаОбъектногоГрафа_("DepthFirstSingleThreadStrategy", "0", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Сравнение различных стратегий обхода объектного графа.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Object graph traverse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Имитация")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "BreadthFirstSingleThreadStrategy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Стратегия", "BreadthFirstSingleThreadStrategy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:прирост скорости", "0")]
        public virtual void СравнениеРазличныхСтратегийОбходаОбъектногоГрафа__BreadthFirstSingleThreadStrategy()
        {
            this.СравнениеРазличныхСтратегийОбходаОбъектногоГрафа_("BreadthFirstSingleThreadStrategy", "0", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Сравнение различных стратегий обхода объектного графа.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Object graph traverse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Имитация")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "DepthFirstMultiThreadStrategy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Стратегия", "DepthFirstMultiThreadStrategy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:прирост скорости", "> 200")]
        public virtual void СравнениеРазличныхСтратегийОбходаОбъектногоГрафа__DepthFirstMultiThreadStrategy()
        {
            this.СравнениеРазличныхСтратегийОбходаОбъектногоГрафа_("DepthFirstMultiThreadStrategy", "> 200", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion
