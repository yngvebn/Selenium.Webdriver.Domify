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
        /// <summary>
        /// Returns a list of TableCells (<TD />) that are descendants of the current element. 
        /// </summary>
        public IList<TD> TableCells
        {
            get
            {
                return this.Find<TD>();
            }
        }

        /// <summary>
        /// Returns a list of TableCells (<TD />) that are immediate children of the current element. 
        /// </summary>
        public IList<TD> OwnTableCells
        {
            get { return this.Find<TD>(false); }
        }

        /// <summary>
        /// Returns the index of the TableRow within a TableRowCollection
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Returns a specific TableCell that matches the specified By constraint.
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public TD OwnTableCell(By constraint)
        {
            return this.Find<TD>(constraint).SingleOrDefault();
        }
    }
}