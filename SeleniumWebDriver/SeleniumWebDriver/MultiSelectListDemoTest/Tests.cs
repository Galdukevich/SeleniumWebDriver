using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumWebDriver.MultiSelectListDemoTest
{
    [TestFixture]
    public class Tests
    {
        const string MuslitSelectWindowXPath = "//*[@id='multi-select']";
        const string URL = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

        [TestCase("Ohio", "Washington", "Florida")]
        public void TestMethod(string ElementName1, string ElementName2, string ElementName3)
        {
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            //create list of elements for selecting
            List<WebElements> list = new List<WebElements>();
            WebElements _webElement1 = new WebElements(ElementName1);
            WebElements _webElement2 = new WebElements(ElementName2);
            WebElements _webElement3 = new WebElements(ElementName3);
            list.Add(_webElement1);
            list.Add(_webElement2);
            list.Add(_webElement3);

            var sendList = list.Select(x => x.ElementName);

            //inizialize MultiSelectionWindow and select elements
            SelectElement selection = new SelectElement(_driver.FindElement(By.XPath(MuslitSelectWindowXPath)));
            selection.SelectByValue(ElementName1);
            selection.SelectByValue(ElementName2);
            selection.SelectByValue(ElementName3);

            //find all selected elements
            var returnedList = selection.AllSelectedOptions;

            //create list of selected elements
            List<WebElements> selectedList = new List<WebElements>();
            WebElements _webElement4 = new WebElements(returnedList[0].Text);
            WebElements _webElement5 = new WebElements(returnedList[1].Text);
            WebElements _webElement6 = new WebElements(returnedList[2].Text);
            selectedList.Add(_webElement4);
            selectedList.Add(_webElement5);
            selectedList.Add(_webElement6);

            var result = selectedList.Select(x => x.ElementName);

            //compare elements for selecting and selected elements
            CollectionAssert.AreEquivalent(result, sendList, "Selected elements are not equal to precondition");

            _driver.Close();
        }
    }
}
