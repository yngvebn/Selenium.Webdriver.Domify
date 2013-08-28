using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
// ReSharper disable InconsistentNaming
    public class TH : WebElement
// ReSharper restore InconsistentNaming
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