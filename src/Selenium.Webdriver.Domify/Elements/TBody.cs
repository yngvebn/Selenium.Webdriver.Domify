using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("tbody")]
    public class TBody: WebElement
    {
        public TR OwnTableRow(By constraint)
        {
            return this.Find<TR>(constraint).SingleOrDefault();
        }

        public TableRowCollection OwnTableRows
        {
            get { return new TableRowCollection(this.Find<TR>()); }
        }
    }

}