using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public class Document : IDocument
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

        public Body Body
        {
            get { return Body.Create(_driver.FindElement(By.TagName("body"))); }
        }

        public IList<Span> Spans
        {
            get { return _driver.FindElements(By.TagName("span")).Select(Span.Create).ToList(); }
        }

        public IList<Frame> Frames
        {
            get { return _driver.FindElements(By.TagName("iframe")).Select(Frame.Create).ToList(); }
        }

        public IList<Div> Divs
        {
            get { return _driver.FindElements(By.TagName("div")).Select(Div.Create).ToList(); }
        }

        public IList<HyperLink> Links
        {
            get { return _driver.FindElements(By.TagName("a")).Select(HyperLink.Create).ToList(); }
        }

        public IList<Table> Tables
        {
            get { return _driver.FindElements(By.TagName("table")).Select(Table.Create).ToList(); }
        }

        public IList<CheckBox> CheckBoxes
        {
            get { return _driver.FindElements(By.TagName("input")).Where(i => i.GetAttribute("type").Equals("checkbox")).Select(CheckBox.Create).ToList(); }
        }

        public IList<SelectList> SelectLists
        {
            get { return _driver.FindElements(By.TagName("select")).Select(SelectList.Create).ToList(); }
        }

        public IList<DateField> DateFields
        {
            get { return _driver.FindElements(By.TagName("input")).Where(i => i.GetAttribute("type").Equals("date")).Select(DateField.Create).ToList(); }
        }

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

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public IEnumerable<IWebElement> ElementsWithTag(string tagName)
        {
            return _driver.FindElements(By.TagName(tagName));
        }



        public T WaitUntilFound<T>(By find, TimeSpan timeout = default(TimeSpan))
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

        public IWebElement FindElement(By @by)
        {
            if (!Settings.AlwaysWaitForElement)
                return _driver.FindElement(@by);
            else
            {
                return TimeoutManager.Execute(Settings.WaitTimeout, () => _driver.FindElement(@by));
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _driver.FindElements(@by);
        }
    }
}