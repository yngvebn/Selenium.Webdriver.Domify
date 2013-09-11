using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "hidden")]
    public class Hidden : WebElement
    {

        public static Hidden Create(IWebElement element)
        {
            return new Hidden(element);
        }

        public Hidden(IWebElement element)
            : base(element)
        {

        }
    }
}