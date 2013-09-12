using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("tbody")]
    public class TBody: WebElement
    {
        public static TBody Create(IWebElement element)
        {
            return new TBody(element);
        }

        private TBody(IWebElement element) :
            base(element)
        {

        }

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