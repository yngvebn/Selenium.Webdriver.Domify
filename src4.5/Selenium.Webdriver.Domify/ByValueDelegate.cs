using System;
using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    public class ByValueDelegate : OpenQA.Selenium.By
    {
        public ByValueDelegate(Func<string, bool> finder)
        {
            FindElementMethod = context => context.FindElements(XPath(".//*[@value]")).SingleOrDefault(elem => finder(elem.GetAttribute("value")));
        }
    }
}