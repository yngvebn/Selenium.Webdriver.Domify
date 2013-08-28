using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
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
            get { return GetAttribute("value"); }
            set
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    Driver.ExecuteJavascript(string.Format("$('#{0}').focus();", Id));
                    Driver.ExecuteJavascript(string.Format("document.getElementById('{0}').value = '{1}'", Id, value));
                    Driver.ExecuteJavascript(string.Format("$('#{0}').keyup();", Id));
                    Driver.ExecuteJavascript(string.Format("$('#{0}').change();", Id));
                }
                else
                    base.Text = value;
            }
        }
    }
}