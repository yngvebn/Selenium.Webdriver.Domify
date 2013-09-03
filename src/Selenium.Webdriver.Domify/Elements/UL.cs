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
                var xPath = Driver.GetElementXPath(this) + "/li";
                return this.FindElements(By.XPath(xPath)).Select(LI.Create).ToList();
            }
        }

        private IEnumerable<LI> ListItems
        {

            get
            {
                return FindElements(By.TagName("li")).Select(LI.Create);
            }
        }

        private UL(IWebElement element) :
            base(element)
        {

        }
    }
}