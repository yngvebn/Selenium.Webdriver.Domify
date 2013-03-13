using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class CheckBox : WebElement
    {
        public static CheckBox Create(IWebElement element)
        {
            return new CheckBox(element);
        }

        private CheckBox(IWebElement element) :
            base(element)
        {

        }

        public bool Checked
        {
            get { return base.GetAttribute("checked") != null; }

            set
            {
                if(value && !Checked) Click();
                if(!value && Checked) Click();
            }
        }

        public IWebElement NextSibling { get; set; }
    }
}