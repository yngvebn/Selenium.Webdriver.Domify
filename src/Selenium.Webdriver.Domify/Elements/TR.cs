using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("tr")]
    public class TR : WebElement
    {
        public static TR Create(IWebElement element)
        {
            return new TR(element);
        }

        private TR(IWebElement element) :
            base(element)
        {

        }

        public IList<TD> TableCells
        {
            get
            {
                return this.Find<TD>();
            }
        }

        public IList<TD> OwnTableCells
        {
            get { return this.Find<TD>(false); }
        }

        public int Index { get; internal set; }

        public TD OwnTableCell(By constraint)
        {
            return this.Find<TD>(constraint).SingleOrDefault();
        }
    }
}