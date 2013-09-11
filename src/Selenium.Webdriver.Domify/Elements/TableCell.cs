using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("td")]
    public class TableCell : WebElement<TableRow>
    {
        public static TableCell Create(IWebElement element)
        {
            return new TableCell(element);
        }

        private TableCell(IWebElement element) :
            base(element)
        {

        }
    }
}