using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("td")]
    public class TD : WebElement<TR>
    {
        public static TD Create(IWebElement element)
        {
            return new TD(element);
        }

        private TD(IWebElement element) :
            base(element)
        {

        }
    }
}