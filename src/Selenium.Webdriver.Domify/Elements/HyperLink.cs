using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("a")]
    public class HyperLink : WebElement
    {
        public static HyperLink Create(IWebElement element)
        {
            return new HyperLink(element);
        }

        protected HyperLink(IWebElement element) :
            base(element)
        {

        }
    }

}