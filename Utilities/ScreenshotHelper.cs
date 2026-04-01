using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Utilities
{
    public class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string folderPath = @"C:\ExtentReport\Screenshots";
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            screenshot.SaveAsFile(filePath);

            return filePath;
        }
    }
}