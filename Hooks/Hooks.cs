using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using SpecFlowDemo.Driver;
using SpecFlowDemo.Reports;
using SpecFlowDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Hooks
{
    [Binding]
    public class Hooks
    {
       // public  IWebDriver driver = null!;
        public static ExtentReports extent = null!;
        public static ExtentTest test = null!;
        private readonly ScenarioContext _scenarioContext;

       
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LoggerHelper.InitLogger();
            extent = ExtentManager.GetInstance();
        }

        [BeforeScenario]
        public void Setup()
        {
            var driver = DriverFactory.InitDriver();

            _scenarioContext["driver"] = driver;

            Hooks.test = Hooks.extent.CreateTest(_scenarioContext.ScenarioInfo.Title);

            Console.WriteLine("BeforeScenario executed");
        }

        [AfterScenario]
        public void TearDown()
        {
            Console.WriteLine("AfterScenario executed");

            var driver = (IWebDriver)_scenarioContext["driver"];  // ✅ IMPORTANT

            if (_scenarioContext.TestError != null)
            {
                var error = _scenarioContext.TestError;

                Hooks.test.Fail($"❌ ERROR: {error?.Message}");
                Hooks.test.Fail($"📍 STACKTRACE:\n{error?.StackTrace}");

                Hooks.test.Info("🌐 URL: " + driver.Url);

                string path = ScreenshotHelper.TakeScreenshot(driver, "failure");
                Hooks.test.AddScreenCaptureFromPath(path);
            }
            else
            {
                Hooks.test.Pass("✅ Test Passed");
            }

            driver.Quit();
            extent.Flush();
        }
        [BeforeStep]
        public void BeforeStep()
        {
            Hooks.test.Info("STEP: " + _scenarioContext.StepContext.StepInfo.Text);
        }
        [AfterStep]
        public void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                Hooks.test.Fail("FAILED STEP: " + _scenarioContext.StepContext.StepInfo.Text);
            }
            else
            {
                Hooks.test.Pass("PASSED STEP: " + _scenarioContext.StepContext.StepInfo.Text);
            }
        }

    }
}
