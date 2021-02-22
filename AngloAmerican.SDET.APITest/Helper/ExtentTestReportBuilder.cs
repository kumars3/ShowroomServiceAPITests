using AngloAmerican.SDET.APITest.Config;
using AngloAmerican.SDET.APITest.Context;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using TechTalk.SpecFlow;

namespace AngloAmerican.SDET.APITest.Helper
{
    public class ExtentTestReportBuilder
    {
        private static ScenarioContext _scenarioContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static string _testReportPath;
        private static CommonContext _commonContext;

        protected ExtentTestReportBuilder(CommonContext commonContext)
        {
            _commonContext = commonContext;
        }

        private static void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError == null)
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
            }
            else
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
            }
        }

        internal static void InitailizeTestReport()
        {
            _testReportPath = ConfigSetUp.GetProjectDirectoryPath() + "\\TestReport\\";
            _extentHtmlReporter = new ExtentHtmlReporter(_testReportPath);
            _extentHtmlReporter.Config.ReportName = "Anglo American SDET API Automation Test Report";
            _extentHtmlReporter.Config.DocumentTitle = "Anglo American SDET API Automation Test Report";
            _extentReports = new ExtentReports();
            //Value of Host Name = Environment.UserDomainName,the machine on which automation tests run
            _extentReports.AddSystemInfo("Host Name", "");
            _extentReports.AddSystemInfo("Tester Name", Environment.UserName);
            _extentReports.AddSystemInfo("OS Version", Environment.OSVersion.ToString());
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        public static void InsertStepsInTestReport()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            {
                switch (scenarioBlock)
                {
                    case ScenarioBlock.Given:
                        CreateNode<Given>();
                        break;
                    case ScenarioBlock.When:
                        CreateNode<When>();
                        break;
                    case ScenarioBlock.Then:
                        CreateNode<Then>();
                        break;
                    default:
                        CreateNode<And>();
                        break;
                }
            }
        }

        internal static void SetScenarioDetails(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }

        internal static void SetFeatureDetails(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _feature = _extentReports.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        internal static void CleanUpReportData()
        {
            _extentReports.Flush();
        }
    }
}
