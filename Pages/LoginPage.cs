using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement Email => wait.Until(d => d.FindElement(By.Name("email")));
        private IWebElement Password => driver.FindElement(By.Name("password"));
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//button[text()='Login']"));
        private IWebElement LoggedInText => wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Logged in as')]")));
        private IWebElement ConsentBtn => driver.FindElement(By.XPath(" //button[@aria-label='Consent']"));

       
        public void Navigate()
        {
            driver.Navigate().GoToUrl("https://automationexercise.com/login");
        }
        public void Login(string email, string password)
        {
            Log.Information($"Entering details: {email} and {password}");
            ConsentBtn.Click();
            Email.SendKeys(email);
            Password.SendKeys(password);
            Log.Information("Clicking login button");
            LoginBtn.Click();
        }

        public bool IsLoggedIn()
        {
            return LoggedInText.Displayed;
        }

    }
}
