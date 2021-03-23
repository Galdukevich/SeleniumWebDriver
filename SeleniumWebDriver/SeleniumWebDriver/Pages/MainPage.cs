using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace SeleniumWebDriver.Pages
{
    public class MainPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;
        private const string _userNamePanelByClass = "uname";
        private const string _logOutButton = "//.[@class = 'button wide auth__reg']";

        //move driver to MainPage and initialize WebElements
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.ClassName, Using = _userNamePanelByClass)]
        [CacheLookup]
        private IWebElement _UserNamePanel;

        [FindsBy(How = How.XPath, Using = _logOutButton)]
        [CacheLookup]
        private IWebElement _LogOutButton;

        //method for finding logged in UserName, with explict waiter (waits until UserName can be found in DOM)
        public string GetUserName(ref string username)
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.Until(x => x.FindElement(By.ClassName(_userNamePanelByClass)));

            username = _UserNamePanel.Text;
            return username;
        }

        //LogOut method with explict waiter (waits until LogOut button is displayed)
        public void LogOut()
        {
            _UserNamePanel.Click();

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.ClassName(_userNamePanelByClass)).Displayed);

            _LogOutButton.Click();
        }

        //move to login page
        public LoginPage OpenLoginPage()
        {
            return new LoginPage(_driver);
        }
    }
}