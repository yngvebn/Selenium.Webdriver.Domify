using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "text")]
    [DOMElement("input", Type = "password")]
    [DOMElement("input", Type = "search")]
    [DOMElement("input", Type = "datetime-local")]
    [DOMElement("input", Type = "datetime")]
    [DOMElement("input", Type = "email")]
    [DOMElement("input", Type = "month")]
    [DOMElement("input", Type = "number")]
    [DOMElement("input", Type = "search")]
    [DOMElement("input", Type = "tel")]
    [DOMElement("input", Type = "time")]
    [DOMElement("input", Type = "url")]
    [DOMElement("input", Type = "week")]
    [DOMElement("textarea")]
    public class TextField : WebElement
    {
        public static TextField Create(IWebElement element)
        {
            return new TextField(element);
        }

        private TextField(IWebElement element) :
            base(element)
        {

        }

        public override string Text
        {
            get { return Value; }
            set { Value = value; }
        }

        public string Value
        {
            get { return GetAttribute("value"); }
            set
            {
                this.TriggerJavascriptEvent("click", "focus");
                this.ClearTextField();
                if (this.SeleniumElement.Displayed)
                {
                    this.SendKeys(value);
                }
                else
                {
                    this.SetElementValue(value);
                }
                this.TriggerJavascriptChange();
            }
        }
    }
}