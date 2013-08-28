using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
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
                if (!string.IsNullOrEmpty(Id))
                {
                  Driver.ExecuteJavascript(string.Format("document.getElementById('{0}').value = '{1}'", Id, value));
                  Driver.TriggerJavascriptChange(Id);

                }
                else
                    base.Text = value;
            }
        }
    }
}