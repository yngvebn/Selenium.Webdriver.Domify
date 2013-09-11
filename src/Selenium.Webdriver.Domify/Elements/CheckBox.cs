using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{

    [DOMElement("input", Type = "checkbox")]
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

        public void Select()
        {
            Checked = true;
        }

        public bool Checked
        {
            get { return GetAttribute("checked") != null; }

            set
            {
                if(value && !Checked) Click();
                if(!value && Checked) Click();
            }
        }

        public IWebElement NextSibling { get; set; }
    }
}