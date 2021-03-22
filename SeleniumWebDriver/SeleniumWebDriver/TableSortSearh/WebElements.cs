using System;
using System.Linq;

namespace SeleniumWebDriver.TableSortSearh
{
    public class WebElements
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public string Age { get; set; }
        public string StartDate { get; set; }
        public string Salary { get; set; }

        public WebElements(string name, string position, string office, string age, string startdate, string salary)
        {
            Name = name;
            Position = position;
            Office = office;
            StartDate = startdate;
            Age = age;
            Salary = salary;
        }
    }
}

