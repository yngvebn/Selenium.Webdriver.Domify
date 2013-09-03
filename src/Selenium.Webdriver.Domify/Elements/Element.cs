using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("*")]
    public class Element : WebElement
    {
        public static Element Create(IWebElement element)
        {
            return new Element(element);
        }

        private Element(IWebElement element) :
            base(element)
        {

        }
    }
}