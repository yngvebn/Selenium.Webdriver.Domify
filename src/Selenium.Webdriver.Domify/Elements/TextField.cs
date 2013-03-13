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

        public void TypeText(string textToType)
        {
            Driver.ExecuteJavascript(string.Format("document.getElementById('{0}').value = '{1}'", Id, textToType));
        }

        public string Value
        {
            get { return GetAttribute("value"); }
            set
            {
                TypeText(value);
            }
        }
    }
}