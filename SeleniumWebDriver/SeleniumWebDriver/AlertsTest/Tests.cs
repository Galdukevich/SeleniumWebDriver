using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebDriver.AlertsTest
{
    [TestFixture]
    public class Tests
    {
        const string _alertBoxXPath = "//*[@class ='btn btn-default']";
        const string _confirmBoxXPath = "//*[@onclick = 'myConfirmFunction()']";
        const string URL = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        const string _expectedErrorAlertBox = "I am an alert box!";
        const string _expectedTextConfirmBox = "Press a button!";
        const string _acceptanceResultConfirmBox = "You pressed OK!";
        const string _dismissingResultConfirmBox = "You pressed Cancel!";
        const string _confirmResultText = "//*[@id='confirm-demo']";

        [Test]
        public void TestAlert()
        {
            IWebElement _AlertBox;
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            //initialize and click alert button
            _AlertBox = _driver.FindElement(By.XPath(_alertBoxXPath));
            _AlertBox.Click();

            //switch to alert, get alert text and close alert
            var alert = _driver.SwitchTo().Alert();          
            var errorText = alert.Text;
            alert.Accept();

            //verify alert text
            Assert.AreEqual(_expectedErrorAlertBox, errorText);

            _driver.Close();
        }

        [Test]
        public void TestConfirmAccept()
        {
            IWebElement _ConfirmBox;
            IWebElement _ConfirmResultText;
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            _ConfirmBox = _driver.FindElement(By.XPath(_confirmBoxXPath));
            _ConfirmResultText = _driver.FindElement(By.XPath(_confirmResultText));
            _ConfirmBox.Click();

            //switch to confirm box, get text and accept confirm box
            var confirmBox = _driver.SwitchTo().Alert();
            var errorText = confirmBox.Text;
            confirmBox.Accept();

            //get result message text, after acceptance confirm box
            var result = _ConfirmResultText.Text;

            //verify confirm box text
            Assert.AreEqual(_expectedTextConfirmBox, errorText);
            Assert.AreEqual(_acceptanceResultConfirmBox, result);

            _driver.Close();
        }

        [Test]
        public void TestConfirmDismiss()
        {
            IWebElement _ConfirmBox;
            IWebElement _ConfirmResultText;
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            _ConfirmBox = _driver.FindElement(By.XPath(_confirmBoxXPath));
            _ConfirmResultText = _driver.FindElement(By.XPath(_confirmResultText));
            _ConfirmBox.Click();

            //switch to confirm box, get text and dismiss confirm box
            var confirmBox = _driver.SwitchTo().Alert();
            var errorText = confirmBox.Text;
            confirmBox.Dismiss();

            //get result message text, after dismissing confirm box
            var result = _ConfirmResultText.Text;

            //verify confirm box text
            Assert.AreEqual(_expectedTextConfirmBox, errorText);
            Assert.AreEqual(_dismissingResultConfirmBox, result);

            _driver.Close();
        }
    }
}

