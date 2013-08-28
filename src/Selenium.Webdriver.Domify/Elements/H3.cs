using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class H3 : WebElement
    {
        public static H3 Create(IWebElement element)
        {
            return new H3(element);
        }

        private H3(IWebElement element) :
            base(element)
        {

        }
         
    }
}