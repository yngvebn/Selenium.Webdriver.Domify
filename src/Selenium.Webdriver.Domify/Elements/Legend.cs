using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("legend")]
    public class Legend : WebElement
    {
        public static Legend Create(IWebElement element)
        {
            return new Legend (element);
        }

        private Legend(IWebElement element) :
            base(element)
        {

        }
    }
}