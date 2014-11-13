using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{

    [DOMElement("input", Type = "checkbox")]
    public class CheckBox : WebElement
    {
        public bool Checked
        {
            get { return GetAttribute("checked") != null; }

            set
            {
                if(value && !Checked) Click();
                if(!value && Checked) Click();
            }
        }
    }
}