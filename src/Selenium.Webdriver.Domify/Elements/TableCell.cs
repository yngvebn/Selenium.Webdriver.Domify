using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("td")]
    public class TableCell : WebElement
    {
        public static TableCell Create(IWebElement element)
        {
            return new TableCell(element);
        }

        private TableCell(IWebElement element) :
            base(element)
        {

        }

        public string CellText()
        {
            return Text;
        }
    }
}