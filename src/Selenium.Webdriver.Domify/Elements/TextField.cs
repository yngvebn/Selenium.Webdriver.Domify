using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "text")]
    [DOMElement("input", Type = "password")]
    [DOMElement("input", Type = "search")]
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
                this.TriggerJavascriptEvent("click");
                this.TriggerJavascriptEvent("focus");
                this.ClearTextField();
                try
                {
                    this.SendKeys(value);
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