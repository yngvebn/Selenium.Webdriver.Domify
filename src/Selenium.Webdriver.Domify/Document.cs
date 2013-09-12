using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.Javascript;

namespace Selenium.Webdriver.Domify
{
    public class Document :ListWebElements, IDocument
    {
        private readonly IWebDriver _driver;

        internal Document(IWebDriver driver)
        {
            _driver = driver;
            Settings = new DocumentSettings()
                {
                    WaitTimeout = TimeSpan.FromSeconds(30),
                    AlwaysWaitForElement = true,
                    EnsureAllElementsHaveId = true
                };
        }

        public Uri Uri
        {
            get
            {
                return new Uri(_driver.Url);
            }
        }

        public IDocumentSettings Settings { get; private set; }

       
        public string PageSource
        {
            get { return _driver.PageSource; }

        }

        public INavigationService Navigation
        {
            get
            {
                return new NavigationService(this);
            }
        }

        public bool IsPageLoaded { get
        {
            return Driver.ExecuteJavascript<string>(new GetDocumentReadyState()).Equals("complete", StringComparison.CurrentCultureIgnoreCase);
        }}

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public T WaitUntilFound<T>(OpenQA.Selenium.By find, TimeSpan timeout = default(TimeSpan))
        {
            return Driver.WaitUntilFound<T>(find, timeout);
        }

        public void GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public override IWebElement FindElement(OpenQA.Selenium.By @by)
        {
            if (!Settings.AlwaysWaitForElement)
                return _driver.FindElement(@by);
            else
            {
                return TimeoutManager.Execute(Settings.WaitTimeout, () => _driver.FindElement(@by));
            }
        }

        public override ReadOnlyCollection<IWebElement> FindElements(OpenQA.Selenium.By @by)
        {
            return _driver.FindElements(@by);
        }
    }
}