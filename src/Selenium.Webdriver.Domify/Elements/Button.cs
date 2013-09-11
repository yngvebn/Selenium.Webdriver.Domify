using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("button")]
    [DOMElement("input", Type = "submit")]
    [DOMElement("input", Type = "button")]
    [DOMElement("input", Type = "image")]
    [DOMElement("input", Type = "reset")]
    public class Button : WebElement
    {
        public static Button Create(IWebElement element)
        {
            return new Button(element);
        }

        private Button(IWebElement element) :
            base(element)
        {

        }

        public override string Text
        {
            get
            {
                if(TagName.Equals("button")) return base.Text;
                else
                {
                    return base.GetAttribute("value");
                }
            }
            set
            {
                if (TagName.Equals("button")) base.SetText(value);
                else
                {
                    base.SetAttribute("value", value);
                }
            }
        }
    }
}