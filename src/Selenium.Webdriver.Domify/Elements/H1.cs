using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("h1")]
    public class H1 : WebElement
    {
        public static H1 Create(IWebElement element)
        {
            return new H1(element);
        }

        private H1(IWebElement element) :
            base(element)
        {

        }


    }
}