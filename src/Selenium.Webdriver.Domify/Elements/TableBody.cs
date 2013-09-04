using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("tbody")]
    public class TableBody: WebElement
    {
        public static TableBody Create(IWebElement element)
        {
            return new TableBody(element);
        }

        private TableBody(IWebElement element) :
            base(element)
        {

        }

        public TableRow OwnTableRow(By constraint)
        {
            return this.Find<TableRow>(constraint).SingleOrDefault();
        }

        public TableRowCollection OwnTableRows
        {
            get { return new TableRowCollection(this.Find<TableRow>()); }
        }
    }

}