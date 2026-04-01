using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Reports
{
    public class ExtentManager
    {
        private static ExtentReports extent = null!;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string reportDir = @"C:\ExtentReport";
                Directory.CreateDirectory(reportDir);

                string reportPath = Path.Combine(reportDir,$"report_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                var htmlReporter = new ExtentSparkReporter(reportPath);
                htmlReporter.Config.DocumentTitle = "Automation Report";
                htmlReporter.Config.ReportName = "BDD Test Results";

                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }

            return extent;
        }
    }
}
