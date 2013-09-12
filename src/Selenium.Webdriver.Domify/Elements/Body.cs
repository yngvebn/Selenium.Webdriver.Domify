using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("body")]
    public class Body : WebElement
    {
        private Body(IWebElement element)
            : base(element)
        {
        }

        public static Body Create(IWebElement element)
        {
            return new Body(element);
        }
    }
}