using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("tr")]
    public class TableRow : WebElement
    {
        public static TableRow Create(IWebElement element)
        {
            return new TableRow(element);
        }

        private TableRow(IWebElement element) :
            base(element)
        {

        }

        public IList<TableCell> TableCells
        {
            get
            {
                return this.Find<TableCell>();
            }
        }

        public IList<TableCell> OwnTableCells
        {
            get { return TableCells; }
        }
        
        public TableCell OwnTableCell(By constraint)
        {
            return this.Find<TableCell>(constraint).SingleOrDefault();
        }
    }
}