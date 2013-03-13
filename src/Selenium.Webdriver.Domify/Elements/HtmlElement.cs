using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class HtmlElement : WebElement
    {
        public static HtmlElement Create(IWebElement element)
        {
            return new HtmlElement(element);
        }

        private HtmlElement(IWebElement element)
            : base(element)
        {

        }
    }
}