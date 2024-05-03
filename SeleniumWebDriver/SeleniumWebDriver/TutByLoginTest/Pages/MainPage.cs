using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.TutByLoginTest.Pages
{
    public class MainPage
    {
        private const string _userNamePanelByClass = "uname";

        private IWebDriver _driver;
        IWebElement _UserNamePanel;

        //move driver to MainPage
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //method for finding logged in UserName
        public string GetUserName()
        {
            //explicit waiter
            WebDriverWait wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(5));
            wait.PollingInterval = System.TimeSpan.FromSeconds(2.5);
            wait.Until(x => x.FindElement(By.ClassName(_userNamePanelByClass)));

            _UserNamePanel = _driver.FindElement(By.ClassName(_userNamePanelByClass));
            return _UserNamePanel.Text;
        }
    }
}