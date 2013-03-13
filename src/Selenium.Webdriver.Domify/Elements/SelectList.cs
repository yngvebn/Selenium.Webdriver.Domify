using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Webdriver.Domify.Elements
{
    public class SelectList : SelectElement
    {
        private readonly IWebElement _webElement;

        public static SelectList Create(IWebElement element)
        {
            return new SelectList(element);
        }

        private RemoteWebElement RemoteWebElement
        {
            get { return _webElement as RemoteWebElement; }
        }
        private SelectList(IWebElement webElement)
            : base(webElement)
        {
            _webElement = webElement;
        }

        public Document DomContainer { get { return RemoteWebElement.WrappedDriver as Document; } }

        public string Id { get { return _webElement.GetAttribute("id"); }set{} }

        public void Option(string textOfOptionToSelect)
        {
            
            this.SelectByText(textOfOptionToSelect);
        }

        public IWebElement SelectedItem
        {
            get { return this.SelectedOption; }
        }
    }
}