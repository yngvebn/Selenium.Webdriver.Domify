using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class Table : WebElement
    {
        public static Table Create(IWebElement element)
        {
            return new Table(element);
        }

        private Table(IWebElement element) :
            base(element)
        {

        }

        public TableBodyCollection TableBodies
        {
            get { return OwnTableBodies; }
        }

        public TableBodyCollection OwnTableBodies
        {
            get { return new TableBodyCollection(FindElements(By.TagName("tbody")).Select(TableBody.Create)); }
        }

        public TableRowCollection OwnTableRows
        {
            get
            {
                return new TableRowCollection(FindElements(By.TagName("tr")).Select(TableRow.Create));
            }
        }

        public THead Head
        {
            get { return THead.Create(FindElement(By.TagName("thead"))); }
        }

        public WebElement Parent { get { return null; } }
    }
}