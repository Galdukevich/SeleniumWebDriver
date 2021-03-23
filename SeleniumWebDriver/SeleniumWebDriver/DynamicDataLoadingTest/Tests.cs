using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.DynamicDataLoadingTest
{
    [TestFixture]
    public class Tests
    {
        const string _getNewUserButtonXPath = "//*[@id='save']";
        const string _userPicXPath = "//*[@id='loading']/img";
        const string URL = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";

        [TestCase]
        public void TestMethod()
        {
            IWebElement _GetNewUserButton;
            IWebElement _UserPicXPath;
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            //initialize and click GetNewUser button
            _GetNewUserButton = _driver.FindElement(By.XPath(_getNewUserButtonXPath));
            _GetNewUserButton.Click();

            //wait for user 5 seconds and check is user exist every 2.5 seconds
            WebDriverWait wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(5));
            wait.PollingInterval = System.TimeSpan.FromSeconds(2.5);
            wait.Until(x => x.FindElement(By.XPath(_userPicXPath)));

            //if user was created, find user picture
            _UserPicXPath = _driver.FindElement(By.XPath(_userPicXPath));

            //verify that user picture is displayed
            Assert.IsTrue(_UserPicXPath.Displayed, "UserPicture is not displayed");

            _driver.Close();
        }
    }
}
