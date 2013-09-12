using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("li")]
    public class LI : WebElement
    {
        public static LI Create(IWebElement element)
        {
            return new LI(element);
        }

        private LI(IWebElement element) :
            base(element)
        {

        }

        
    }
}