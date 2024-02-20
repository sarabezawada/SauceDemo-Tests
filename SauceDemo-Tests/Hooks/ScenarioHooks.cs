using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Dynamitey.DynamicObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo_Tests.Utils.TestData;
using SauceDemoTests.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SauceDemoTests.Hooks
{
    [Binding]
    public sealed class ScenarioHooks
    {
        private static IObjectContainer ObjectContainer;
        private static IWebDriver WebDriver;
        private static List<ProductOrderList> ProductOrderList;
        private static ExtentHtmlReporter ExtentHtmlReporter;
        private static ExtentReports ExtentReports;
        private static ExtentTest Feature;
        private static ExtentTest Scenario;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void TestInitialize()
        {
            ExtentHtmlReporter = new ExtentHtmlReporter("C:\\Users\\sarab\\source\\repos\\SauceDemo-Tests\\SauceDemo-Tests\\TestReports\\");
            ExtentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(ExtentHtmlReporter);
        }

        [BeforeFeature]
        public static void InitializeSetting()
        {
            var FeatureTitle = FeatureContext.Current.FeatureInfo.Title;
            Feature = ExtentReports.CreateTest<Feature>(FeatureTitle);

            var browser = ConfigurationManager.AppSettings["browser"];
            Browsers browsers = new Browsers(WebDriver);
            WebDriver = browsers.LaunchBrwoser(browser);
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var UserName = TestContext.CurrentContext.Test.Arguments[0].ToString();
            var Password = TestContext.CurrentContext.Test.Arguments[1].ToString();
            var UserInfo = "user for Username: " + UserName + " and Password: " + Password;
            var ScenarioTitle = ScenarioContext.Current.ScenarioInfo.Title.Replace("user", UserInfo);
            Scenario = Feature.CreateNode<Scenario>(ScenarioTitle);

            ObjectContainer.RegisterInstanceAs<IWebDriver>(WebDriver);
            ProductOrderList = new List<ProductOrderList>();
            ObjectContainer.RegisterInstanceAs<List<ProductOrderList>>(ProductOrderList);
        }

        [AfterStep]
        public void AfterEachStep()
        {
            var ScrenaioStepText = ScenarioStepContext.Current.StepInfo.Text.ToString();
            var StepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var TestError = ScenarioContext.Current.TestError;

            if (TestError == null)
            {
                if (StepType == "Given")
                    Scenario.CreateNode<Given>(ScrenaioStepText);
                else if (StepType == "When")
                    Scenario.CreateNode<And>(ScrenaioStepText);
                else if (StepType == "And")
                    Scenario.CreateNode<And>(ScrenaioStepText);
                else if (StepType == "Then")
                    Scenario.CreateNode<Then>(ScrenaioStepText);
            }
            else if (TestError != null)
            {
                if (StepType == "Given")
                    Scenario.CreateNode<Given>(ScrenaioStepText).Fail(TestError.Message.ToString());
                else if (StepType == "When")
                    Scenario.CreateNode<And>(ScrenaioStepText).Fail(TestError.Message.ToString());
                else if (StepType == "And")
                    Scenario.CreateNode<And>(ScrenaioStepText).Fail(TestError.Message.ToString());
                else if (StepType == "Then")
                    Scenario.CreateNode<Then>(ScrenaioStepText).Fail(TestError.Message.ToString());
            }
        }

        [AfterFeature]
        public static void TearDownFrameworkSettings()
        {
            ObjectContainer.Dispose();
            WebDriver.Close();
            WebDriver.Quit();
            WebDriver.Dispose();
        }

        [AfterTestRun]
        public static void AfterEachTestRun()
        {
            ExtentReports.Flush();
        }
    }
}