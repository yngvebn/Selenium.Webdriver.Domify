using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("textarea")]
    public class TextArea : WebElement
    {
        public static TextArea Create(IWebElement element)
        {
            return new TextArea(element);
        }

        public TextArea(IWebElement element) :
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
            get { return this.GetAttribute("value"); }
            set
            {
                this.SetElementValue("value");
                base.Text = value;
                this.TriggerJavascriptChange();
            }
        }
    }
}