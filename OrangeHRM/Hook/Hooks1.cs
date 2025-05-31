using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OrangeHRM.Utilities;
using Reqnroll;
using Reqnroll.BoDi;
using OrangeHRM.Configration;
[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace OrangeHRM.Hook
{
    [Binding]
    internal class Hook1 : ExtentReport
    {

        private readonly IObjectContainer _objectContainer;
        public IWebDriver _driver;

        WebdriverSupport _webdriverSupport;
        public Hook1(WebdriverSupport webdriverSupport)
        {
            _webdriverSupport = webdriverSupport;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenariocontext)
        {

            _webdriverSupport.InitializeBrowser(ConfigurationManager.BrowserName);
            _scenario = _feature.CreateNode<Scenario>(scenariocontext.ScenarioInfo.Title);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            _webdriverSupport.CloseApplicationUnderTest();
        }
        [AfterStep]
        public void AfterStep(IWebDriver driver, ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;



            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }


            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                       MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}