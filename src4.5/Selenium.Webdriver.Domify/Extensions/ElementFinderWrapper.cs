using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify
{
    public class ElementFinderWrapper
    
    {
        private readonly Page Page;
        private readonly By _finder;

        public ElementFinderWrapper(Page page, By finder)
        {
            Page = page;
            _finder = finder;
        }

        public T Get<T>() where T : WebElement, new()
        {
            return WebElement.Create<T>(Page.Document.FindElement(_finder));
        }
    }
}