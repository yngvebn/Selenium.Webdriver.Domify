using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

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
            get { return new TableBodyCollection(this.Find<TBody>()); }
        }

        public IList<TD> TableCells
        {
            get { return this.Find<TD>(); }
        }

        public IList<TR> TableRows
        {
            get { return this.Find<TR>(); }
        } 

        public TableRowCollection OwnTableRows
        {
            get
            {
                return new TableRowCollection(this.Find<TR>(false));
            }
        }

        public THead Head
        {
            get { return this.Find<THead>().FirstOrDefault(); }
        }

        
    }
}