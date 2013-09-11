using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("span")]
    public class Span : WebElement
    {
        public static Span Create(IWebElement element)
        {
            return new Span(element);
        }

        private Span(IWebElement element) :
            base(element)
        {

        }
    }
}