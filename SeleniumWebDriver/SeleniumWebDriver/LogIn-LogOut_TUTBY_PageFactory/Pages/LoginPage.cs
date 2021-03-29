using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace SeleniumWebDriver.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;
        private const string URL = "https://tut.by/";
        private const string _loginPopUpButton = "enter";
        private const string _loginName = "login";
        private const string _passwordName = "password";
        private const string _loginButton = ".m-green";

        //LoginPage constractor with initializing WebElements using PageFactory and navigating to URL
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _driver.Navigate().GoToUrl(URL);

            Screenshot screenshot2 = _driver.TakeScreenshot();
            var fileName = $"screenshot123-{DateTime.Now.Ticks}-{Thread.CurrentThread.ManagedThreadId}.png";
            screenshot2.SaveAsFile(fileName);
        }

        [FindsBy(How = How.ClassName, Using = _loginPopUpButton)]
        [CacheLookup]
        private IWebElement _LoginPopUpButton;

        [FindsBy(How = How.Name, Using = _loginName)]
        [CacheLookup]
        private IWebElement _Login;

        [FindsBy(How = How.Name, Using = _passwordName)]
        [CacheLookup]
        private IWebElement _Password;

        [FindsBy(How = How.CssSelector, Using = _loginButton)]
        [CacheLookup]
        private IWebElement _Enter;

        //Method for Login with user credentials, with explict waiter (waits until LoginName input field is displayed)
        public void LogIn(string login, string password)
        {
            _LoginPopUpButton.Click();

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.Name(_loginName)).Displayed);

            _Login.SendKeys(login);
            _Password.SendKeys(password);
            _Enter.Click();
        }

        //method to verify, that Login button is displayed, with explict waiter (waits until LoginButton can be found in DOM)
        public bool EnterButtonIsDisplayed()
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.ClassName(_loginPopUpButton)));

            var result = _LoginPopUpButton.Displayed;
            return result;
        }

        //move to main page
        public MainPage OpenMainPage()
        {
            return new MainPage(_driver);
        }
    }
}