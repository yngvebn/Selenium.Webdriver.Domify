using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("thead")]
    public class THead : WebElement
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
                return new THCollection(this.Find<TH>());
            }
        }

    }
}