using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("*")]
    public class HtmlElement : WebElement
    {
        public static HtmlElement Create(IWebElement element)
        {
            return new HtmlElement(element);
        }

        private HtmlElement(IWebElement element)
            : base(element)
        {

        }
    }
}