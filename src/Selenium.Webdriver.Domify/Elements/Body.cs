using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("body")]
    public class Body : WebElement
    {
        private Body(IWebElement element)
            : base(element)
        {
        }

        public static Body Create(IWebElement element)
        {
            return new Body(element);
        }
    }
}