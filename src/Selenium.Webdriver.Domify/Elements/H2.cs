using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class H2 : WebElement
    {
        public static H2 Create(IWebElement element)
        {
            return new H2(element);
        }

        private H2(IWebElement element) :
            base(element)
        {

        }

     
    }
}