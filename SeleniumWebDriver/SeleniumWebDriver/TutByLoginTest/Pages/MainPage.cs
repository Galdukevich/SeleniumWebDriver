using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.TutByLoginTest.Pages
{
    public class MainPage
    {
        private const string _userNamePanelByClass = "uname";

        private IWebDriver _driver;
        IWebElement _UserNamePanel;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetUserName(ref string username)
        {
            //explicit waite
            WebDriverWait wait = new WebDriverWait(_driver, new System.TimeSpan(5000));
            wait.PollingInterval = new System.TimeSpan(2500);            
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(_userNamePanelByClass)));

            _UserNamePanel = _driver.FindElement(By.ClassName(_userNamePanelByClass));
            username = _UserNamePanel.Text;
            return username;
        }
    }
}