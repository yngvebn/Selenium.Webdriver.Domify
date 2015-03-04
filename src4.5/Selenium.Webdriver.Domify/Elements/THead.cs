using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("thead")]
    public class THead : WebElement
    {
        public THCollection OwnTableHeaderColumns
        {
            get
            {
                return new THCollection(this.Find<TH>());
            }
        }

    }
}