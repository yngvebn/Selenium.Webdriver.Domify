using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "range")]
    public class Range : WebElement
    {

        public static Range Create(IWebElement element)
        {
            return new Range(element);
        }

        public Range(IWebElement element)
            : base(element)
        {

        }
    }
}