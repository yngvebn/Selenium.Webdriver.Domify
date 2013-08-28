using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class LI : WebElement
    {
        public static LI Create(IWebElement element)
        {
            return new LI(element);
        }

        private LI(IWebElement element) :
            base(element)
        {

        }

        public string CellText()
        {
            return Text;
        }

        
    }
}