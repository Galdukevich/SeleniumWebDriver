using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.TableSortSearh
{
    public class FinalElements
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }

        public FinalElements(string name, string position, string office)
        {
            Name = name;
            Position = position;
            Office = office;
        }
    }
}
