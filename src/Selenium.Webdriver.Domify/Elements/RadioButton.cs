using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type="radio")]
    public class RadioButton : WebElement
    {
        public static RadioButton Create(IWebElement element)
        {
            return new RadioButton(element);
        }

        private RadioButton(IWebElement element) :
            base(element)
        {

        }

        public bool Checked
        {
            get { return base.GetAttribute("checked") != null; }

            set
            {
                if (value && !Checked) Click();
                if (!value && Checked) Click();
            }
        }
    }
}