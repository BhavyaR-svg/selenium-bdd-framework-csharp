using AventStack.ExtentReports;
using NUnit.Framework;
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

    //[Binding]
    public class Hooks1
    {
        readonly ScenarioContext _ScenarioContext = null!;
        static ExtentTest test = null!;
        static ExtentReports extent = null!;


        public Hooks1(ScenarioContext scenarioContext)
        {
            _ScenarioContext = scenarioContext;


        }
        [BeforeScenario]
        public void Setup()
        {
            var driver = DriverFactory.InitDriver();
            _ScenarioContext["driver"] = driver;
            Hooks.test = Hooks.extent.CreateTest(_ScenarioContext.ScenarioInfo.Title);
            Console.WriteLine("Before Scenario Exceuted");


        }

        [AfterScenario]
        public void TearDown()
        {
            var driver = (IWebDriver)_ScenarioContext["driver"];
            if(_ScenarioContext.TestError !=null)
            {
                var error = _ScenarioContext.TestError;

                Hooks.test.Fail("Scenario Failed"+ error.Message);
                Hooks.test.Fail("Stack trace of error"+error.StackTrace);
                Hooks.test.Info("Url info"+driver.Url);

                string path= ScreenshotHelper.TakeScreenshot(driver,"Failure");
                Hooks.test.AddScreenCaptureFromPath(path);


            }

            else
            {
                Hooks.test.Pass("Test passed");
            }

            driver.Quit();
            extent.Flush();

        }
        [BeforeTestRun]
        public void BeforeTestRun()
        {
            extent = ExtentManager.GetInstance();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Hooks.test.Info("Step"+_ScenarioContext.StepContext.StepInfo.Text);

        }
        [AfterStep]
        public void AfterStep()
        {
            if(_ScenarioContext.TestError !=null)
            {
                Hooks.test.Fail("Step Failed"+ _ScenarioContext.StepContext.StepInfo.Text);

            }

            else
            {
                Hooks.test.Pass("Step Passed"+ _ScenarioContext.StepContext.StepInfo.Text);
            }
        }

    }

}

