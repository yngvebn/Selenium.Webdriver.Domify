using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
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

        public IList<TableCell> TableCells{get { return FindElements(By.TagName("td")).Select(TableCell.Create).ToList(); }}

        public IList<TableCell> OwnTableCells
        {
            get { return TableCells; }
        }

        public IList<HtmlElement> Elements
        {
            get { return this.FindElements(By.XPath("./child::*")).Select(HtmlElement.Create).ToList(); }
            
        }

        public int Index { get; set; }

        public TableCell OwnTableCell(By constraint)
        {
            return TableCell.Create(FindElements(constraint).First(c => c.TagName == "td"));
        }
    }
}