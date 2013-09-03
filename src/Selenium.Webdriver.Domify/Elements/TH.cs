using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("th")]
    public class TH : WebElement
    {
        public static TH Create(IWebElement element)
        {
            return new TH(element);
        }

        private TH(IWebElement element) :
            base(element)
        {

        }
    }
}