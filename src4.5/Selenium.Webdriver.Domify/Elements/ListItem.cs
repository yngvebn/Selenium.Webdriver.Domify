using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class ListItem : WebElement
    {
        public static ListItem Create(IWebElement element)
        {
            return new ListItem(element);
        }

        private ListItem(IWebElement element) :
            base(element)
        {

        }

        public string CellText()
        {
            return Text;
        }

        
    }
}