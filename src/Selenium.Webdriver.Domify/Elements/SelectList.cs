using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("select")]
    public class SelectList : WebElement
    {
        private readonly SelectElement _wrappedSelectElement;

        public static SelectList Create(IWebElement element)
        {
            return new SelectList(element);
        }

        public IList<SelectListItem> Options
        {
            get { return Driver.SelectListItems(); }
        }

        private SelectList(IWebElement webElement)
            : base(webElement)
        {
            _wrappedSelectElement = new SelectElement(webElement);
        }



        public IWebElement SelectedOption
        {
            get { return _wrappedSelectElement.SelectedOption; }
        }

        public void SelectByText(string textOfOptionToSelect)
        {
            _wrappedSelectElement.SelectByText(textOfOptionToSelect);
        }

        public void SelectByValue(string valueOfOptionToSelect)
        {
            _wrappedSelectElement.SelectByValue(valueOfOptionToSelect);
        }
        public void SelectByIndex(int indexOfOptionToSelect)
        {
            _wrappedSelectElement.SelectByIndex(indexOfOptionToSelect);
        }
    }
}