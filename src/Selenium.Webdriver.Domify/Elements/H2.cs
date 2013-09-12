using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("h2")]
    public class H2 : WebElement
    {
        public static H2 Create(IWebElement element)
        {
            return new H2(element);
        }

        private H2(IWebElement element) :
            base(element)
        {

        }

     
    }
}