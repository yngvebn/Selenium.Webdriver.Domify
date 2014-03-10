using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("ul")]
    public class UL : WebElement
    {
        public LI this[int index]{
            get { return ListItems.ToList()[index]; }}


        public IList<LI>  OwnListItems
        {
            get
            {
                return this.Find<LI>(false);
            }
        }

        private IEnumerable<LI> ListItems
        {

            get { return this.Find<LI>(); }
        }

    }
}