using AngloAmerican.SDET.APITest.Helper;
using log4net;
using TechTalk.SpecFlow;

namespace AngloAmerican.SDET.APITest.Hooks
{
      [Binding]
        public class SpecFlowHooks
        {
            private static readonly ILog Logger = ExceptionLogger.GetLogger(typeof(SpecFlowHooks));     
                       
            [BeforeScenario]
            private void BeforeScenario(ScenarioContext scenarioContext)
            {
            ExtentTestReportBuilder.SetScenarioDetails(scenarioContext);
            }
        
            [BeforeFeature]
            public static void BeoforeFeature(FeatureContext featureContext)
            {
                ExtentTestReportBuilder.SetFeatureDetails(featureContext);
            }

            [BeforeTestRun]
            public static void InitializeReport()
            {
                ExtentTestReportBuilder.InitailizeTestReport();
            }

            [AfterTestRun]
            public static void AfterTestRunTearDown()
            {
            ExtentTestReportBuilder.CleanUpReportData();
            Logger.Info("Test run complete, resources disposed");
            }

            [AfterStep]
            private void InsertStepsInTestReport()
            {
                ExtentTestReportBuilder.InsertStepsInTestReport();
            }
        }
}
