using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("option")]
    public class Option : WebElement
    {

        public bool IsSelected
        {
            get { return GetAttribute("selected") != null; }
        }

    }
}