using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class SelectListItem : WebElement
    {
        public static SelectListItem Create(IWebElement element)
        {
            return new SelectListItem(element);
        }

        private SelectListItem(IWebElement element) :
            base(element)
        {
        }

        public bool IsSelected
        {
            get { return GetAttribute("selected") != null; }
        }

    }
}