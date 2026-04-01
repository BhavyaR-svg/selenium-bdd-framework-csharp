using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Reports
{
    
    public class ExtentManager1 
    {
        public static ExtentReports extent = null!;

        public static ExtentReports GetInstance()
        {
            string DirPath = @"C:\ExtentReports";
            Directory.CreateDirectory(DirPath);
            string path = Path.Combine(DirPath,$"Reportpath_{DateTime.Now:yyyyMMdd_HHmmss}.html");
            var report = new ExtentSparkReporter(path);
            report.Config.DocumentTitle = "Data report";
            report.Config.ReportName = "BDD report";

            extent = new ExtentReports();
            extent.AttachReporter(report);

            return extent;
        }

        public static string GetScreenshot(IWebDriver driver)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string directoryPath = @"C:\ExtentReport\Report";
            Directory.CreateDirectory(directoryPath);
            string fullPath = Path.Combine(directoryPath,$"Report_{DateTime.Now:ddMMyyyy_HHmmss}.png");

            screenshot.SaveAsFile(fullPath);

            return fullPath;
        }
    }
}
