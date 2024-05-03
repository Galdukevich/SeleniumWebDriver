using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.DownloadProgress
{
    [TestFixture]
    public class Tests
    {
        const string URL = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        const string _downloadButtonXPath = "//*[@id='cricle-btn']";
        const string _percentTextXPath = "//*[@class='percenttext']";
        const string _50percentXPath = "//*[contains(@class, 'clipauto')]";

        [Test]
        public void TestAlert()
        {
            IWebElement _DownloadButton;
            IWebElement _PercentTextXPath;
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            //initialize and click download button
            _PercentTextXPath = _driver.FindElement(By.XPath(_percentTextXPath));
            _DownloadButton = _driver.FindElement(By.XPath(_downloadButtonXPath));
            _DownloadButton.Click();

            //wait until download will be >=50%
            WebDriverWait wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(30));
            wait.PollingInterval = System.TimeSpan.FromSeconds(0.15);
            wait.Until(x => x.FindElement(By.XPath(_50percentXPath)));

            //refresh page
            _driver.Navigate().Refresh();

            _driver.Close();
        }
    }
}