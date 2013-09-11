using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("div")]
    public class Div : WebElement
    {
        public static Div Create(IWebElement element)
        {
            return new Div(element);
        }

        private Div(IWebElement element) :
            base(element)
        {

        }
    }
}