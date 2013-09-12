using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("form")]
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