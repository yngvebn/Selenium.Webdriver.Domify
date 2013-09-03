using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input")]
    public class Input : WebElement
    {
        public static Input Create(IWebElement element)
        {
            return new Input(element);
        }

        private Input(IWebElement element) :
            base(element)
        {

        }
    }
}