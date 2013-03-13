using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class Span : WebElement
    {
        public static Span Create(IWebElement element)
        {
            return new Span(element);
        }

        private Span(IWebElement element) :
            base(element)
        {

        }
    }
}