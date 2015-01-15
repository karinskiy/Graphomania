﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Object graph traverse", "In order to avoid silly mistakes\nAs a math idiot\nI want to be told the sum of two" +
                    " numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Анализ графа.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Object graph traverse")]
        public virtual void АнализГрафа_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Анализ графа.", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Тип объекта",
                        "Аргументы конструктора",
                        "Имя экземпляра",
                        "Связан с",
                        "Метод присвоения"});
            table1.AddRow(new string[] {
                        "HeatingNetwork",
                        "ctor: \"Теплосеть 1\"",
                        "network",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "HeatingSource",
                        "ctor: \"Котельная 1\", network",
                        "hs1",
                        "",
                        ""});
            table1.AddRow(new string[] {
                        "ConnectionPoint",
                        "method: \"p1\"",
                        "hs1-point1",
                        "hs1",
                        "CreateConnectionPoint"});
            table1.AddRow(new string[] {
                        "Location",
                        "ctor:",
                        "location1",
                        "hs1-point1",
                        "Point"});
#line 7
 testRunner.Given("на входе будет объектный граф, описанный таблицей, типы объектов лежат в сборке \"" +
                    "DomainModel\":", ((string)(null)), table1, "Допустим ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Имя экземпляра",
                        "Свойство",
                        "Значение"});
            table2.AddRow(new string[] {
                        "network",
                        "Description",
                        "\"Тепловая сеть\""});
            table2.AddRow(new string[] {
                        "hs1-point1",
                        "Location",
                        "@location1"});
#line 13
 testRunner.And("свойства объектов содержат следующие значения:", ((string)(null)), table2, "К тому же ");
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
                        "HeatingNetwork",
                        "1",
                        "",
                        "",
                        "",
                        "{ Name: \"Теплосеть 1\", Description: \"Тепловая сеть\" }"});
            table3.AddRow(new string[] {
                        "Node",
                        "HeatingSource",
                        "2",
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
                        "Connectables",
                        ""});
#line 18
 testRunner.Then("на выходе будет список элементов, описывающих объекты объектного графа:", ((string)(null)), table3, "Тогда ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
