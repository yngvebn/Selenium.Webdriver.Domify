using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("th")]
    public class TH : WebElement
    {
        public static TH Create(IWebElement element)
        {
            return new TH(element);
        }

        private TH(IWebElement element) :
            base(element)
        {

        }
    }
}