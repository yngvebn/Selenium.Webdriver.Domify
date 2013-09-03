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

            return TableRow.Create(FindElements(constraint).First(c => c.TagName == "tr"));
        }

        public TableRowCollection OwnTableRows
        {
            get { return new TableRowCollection(FindElements(By.TagName("tr")).Select(TableRow.Create)); }
        }
    }

}