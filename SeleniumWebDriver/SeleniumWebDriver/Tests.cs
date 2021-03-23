using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.Pages;
using System;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class Tests
    {
        IWebDriver _driver;
        WebDriverWait wait;

        [SetUp]
        public void PreparingTest()
        {
            _driver = new FirefoxDriver();
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        }

        [TearDown]
        public void ReleaseTest()
        {
            _driver.Close();
        }

        [TestCase("seleniumtests@tut.by", "123456789zxcvbn", "Selenium Test", "")]

        public void TestMethod(string login, string password, string username, string loggedInUser)
        {

            //create login page and initialize WebElements
            LoginPage loginPage = new LoginPage(_driver);

            //enter login and password and sign in
            loginPage.LogIn(login, password);

            //create main page and initialize WebElements
            MainPage mainPage = loginPage.OpenMainPage();

            //get logged in username
            mainPage.GetUserName(ref loggedInUser);

            //make sure that user is logged in
            Assert.AreEqual(username, loggedInUser);

            //logout
            mainPage.LogOut();

            //create LoginPage again, after LogOut
            LoginPage logOutPage = mainPage.OpenLoginPage();

            //make sure that user is logged out
            Assert.IsTrue(logOutPage.EnterButtonIsDisplayed());         
        }        
    }
}