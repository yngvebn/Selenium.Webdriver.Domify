using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class Div : WebElement
    {
        public static Div Create(IWebElement element)
        {
            return new Div(element);
        }

        private Div(IWebElement element) :
            base(element)
        {

        }
    }
}