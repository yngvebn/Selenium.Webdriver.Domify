using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "text")]
    [DOMElement("input", Type = "password")]
    [DOMElement("input", Type = "search")]
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
                try
                {
                    if (this.SeleniumElement.Displayed)
                    {
                        this.SendKeys(value);
                    }
                    else
                    {
                        this.SetElementValue(value);
                    }
                }
                catch (ElementNotVisibleException)
                {
                    this.SetElementValue(value);
                }
                this.TriggerJavascriptChange();
            }
        }
    }
}