using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("ul")]
    public class UL : WebElement
    {
        public LI this[int index]{
            get { return ListItems.ToList()[index]; }}

        public static UL Create(IWebElement element)
        {
            return new UL(element);
        }

        public IList<LI>  OwnListItems
        {
            get
            {
                var xPath = this.GetElementXPath() + "/li";
                return this.Find<LI>(By.XPath(xPath));
            }
        }

        private IEnumerable<LI> ListItems
        {

            get { return this.Find<LI>(); }
        }

        private UL(IWebElement element) :
            base(element)
        {

        }
    }
}