using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("iframe")]
    public class Frame : WebElement
    {
        public static Frame Create(IWebElement element)
        {
            return new Frame(element);
        }

        private Frame(IWebElement element) :
            base(element)
        {

        }
    }
}