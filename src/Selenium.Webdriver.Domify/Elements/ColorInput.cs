using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "color")]
    public class ColorInput: WebElement
    {

        public static ColorInput Create(IWebElement element)
        {
            return new ColorInput(element);
        }

        public ColorInput(IWebElement element):base(element)
        {
            
        }
    }
}