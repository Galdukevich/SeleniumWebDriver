using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumWebDriver.TableSortSearh
{
    [TestFixture]
    public class Tests
    {
        const string URL = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        const string _showEntriesXPath = "//*[@name='example_length']"; 
        const string _customerListXPath = "//tr[contains(@class, 'odd') or contains(@class, 'even')]/td";
        const string _pageListXPath = "//*[@id = 'example_paginate']/span/*";
        const string rowsOnPage = "10";

        [TestCase(40, 100000)]
        public void TestTableSort(int x, int y)
        {
            IWebDriver _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl(URL);

            //select 10 rows in show entries drop-down
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.XPath(_showEntriesXPath)));
            dropdown.SelectByValue(rowsOnPage);

            //find count of pages for cicle
            List<IWebElement> _PageCount = _driver.FindElements(By.XPath(_pageListXPath)).ToList();

            //ResultList (Name, Position, Office), that filled using cicle bellow 
            List<FinalElements> ResultList = new List<FinalElements>();

            //cicle for going through all pages
            for (int m = 0; m < _PageCount.Count; m++)
            {
                //find pagination in each cicle iteration and click next page
                List<IWebElement> _PageList = _driver.FindElements(By.XPath(_pageListXPath)).ToList();
                _PageList[m].Click();

                //create list of web elements for each property (Name, Position, Office, Age, StartDate, Salary) for current page
                List<IWebElement> _CustomerList = _driver.FindElements(By.XPath(_customerListXPath)).ToList();

                //cicle for: 
                // 1. sending all web elements(Name, Position, Office, Age, StartDate, Salary) in WebElements constructor, 
                // 2. execute condition for age > x and salary <= y 
                // 3. return filled result property(Name, Position, Office) using FinalElements contructor to ResultList
                for (int i = 0; i < _CustomerList.Count; i++)
                {
                    //1. sending all web elements(Name, Position, Office, Age, StartDate, Salary) in WebElements constructor
                    var tempList = new WebElements(name: _CustomerList[i].Text,
                                            position: _CustomerList[++i].Text,
                                            office: _CustomerList[++i].Text,
                                            age: _CustomerList[++i].Text,
                                            startdate: _CustomerList[++i].Text,
                                            salary: _CustomerList[++i].Text);

                    // 2. execute condition for age > x and salary <= y 
                    int intAge = int.Parse(tempList.Age);
                    int intSalary;
                    int.TryParse(string.Join("", tempList.Salary.Where(c => char.IsDigit(c))), out intSalary);

                    if (intAge > x)
                    {
                        if (intSalary <= y)
                        {
                            // 3. return filled result property(Name, Position, Office) using FinalElements contructor to ResultList
                            var result = new FinalElements(tempList.Name, tempList.Position, tempList.Office);
                            ResultList.Add(result);
                        }
                    }
                }
            }
            _driver.Close();
        }
    }
}
