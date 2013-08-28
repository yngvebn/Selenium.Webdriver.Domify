using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
// ReSharper disable InconsistentNaming
    public class THead : WebElement
// ReSharper restore InconsistentNaming
    {
        public static THead Create(IWebElement element)
        {
            return new THead(element);
        }

        private THead(IWebElement element) :
            base(element)
        {

        }

        public THCollection OwnTableHeaderColumns
        {
            get
            {
                return new THCollection(FindElements(By.TagName("th")).Select(TH.Create));
            }
        }

    }
}