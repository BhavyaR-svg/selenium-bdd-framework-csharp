using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Serilog;
using SpecFlowDemo.Hooks;
using SpecFlowDemo.Models;
using SpecFlowDemo.Pages;
using SpecFlowDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Step_Definitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["driver"];   // ✅ retrieve driver
            loginPage = new LoginPage(driver);
        }

        [Given(@"User is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            Log.Information("Navigating to login page");

            loginPage.Navigate();
        }

        [When(@"User enters valid credentials")]
        public void WhenUserEntersValidCredentials()
        {
            loginPage.Login("your_email@gmail.com", "your_password");
        }

        [When(@"Clicks login button")]
        public void WhenClicksLoginButton()
        {
            // already handled inside Login()
        }

        [Then(@"User should be logged in successfully")]
        public void ThenUserShouldBeLoggedInSuccessfully()
        {
            try
            {
                Log.Information("Verifying if user is logged in");

                bool isLoggedIn = loginPage.IsLoggedIn();

                Assert.IsTrue(isLoggedIn, "Login failed - user not logged in");

                Log.Information("User login successful");
               
            }
            catch (Exception ex)
            {
                Log.Error("Login verification failed: " + ex.Message);
                                
                throw; 
            }
            // Assert.IsTrue(loginPage.IsLoggedIn(), "Login failed");
        }

        [When(@"User enters credentials ""(.*)"" and ""(.*)""")]
        public void WhenUserEntersCredentials(string username, string password)
        {
            loginPage.Login(username, password);
        }


        [When("User logs in with valid data from json")]
        public void WhenUserLogsInWithValidDataFromJson()
        {
            
        string path = Path.Combine(Directory.GetCurrentDirectory(), "TestData/loginData.json");

        var data = JsonHelper.ReadJson<LoginTestData>(path);

        loginPage.Login(data.ValidUser.Username, data.ValidUser.Password);
    }

}
   
}
