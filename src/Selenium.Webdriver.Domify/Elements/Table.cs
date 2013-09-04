using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("table")]
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
            get { return new TableBodyCollection(this.Find<TableBody>()); }
        }

        public TableRowCollection OwnTableRows
        {
            get
            {
                return new TableRowCollection(this.Find<TableRow>());
            }
        }

        public THead Head
        {
            get { return this.Find<THead>().FirstOrDefault(); }
        }

        
    }
}