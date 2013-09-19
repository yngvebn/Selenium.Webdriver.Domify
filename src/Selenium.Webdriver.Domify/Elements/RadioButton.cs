using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type="radio")]
    public class RadioButton : WebElement
    {

        public bool Checked
        {
            get { return base.GetAttribute("checked") != null; }

            set
            {
                if (value && !Checked) Click();
            }
        }
    }
}