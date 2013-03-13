using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class Button : WebElement
    {
        public static Button Create(IWebElement element)
        {
            return new Button(element);
        }

        private Button(IWebElement element) :
            base(element)
        {

        }
    }
}