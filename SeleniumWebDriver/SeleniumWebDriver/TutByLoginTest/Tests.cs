using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumWebDriver.TutByLoginTest.Pages;

namespace SeleniumWebDriver.TutByLoginTest
{
    [TestFixture]
    public class Tests
    {
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn", "Selenium Test", "")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn", "Selenium Test", "")]

        public void TestMethod(string login, string password, string username, string loggedInUser)
        {
            IWebDriver _driver = new FirefoxDriver();
         
            //create new login page
            LoginPage loginPage = new LoginPage(_driver);

            //enter login and password
            loginPage.LogIn(login, password);

            //go to MainPage
            MainPage mainPage = loginPage.OpenMainPage();

            //get logged in username
            mainPage.GetUserName(ref loggedInUser);

            //compare usernames
            Assert.AreEqual(username, loggedInUser);

            _driver.Close();
        }
    }
}