using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class Form : WebElement
    {
        public static Form Create(IWebElement element)
        {
            return new Form(element);
        }

        private Form(IWebElement element) :
            base(element)
        {

        }
    }
}