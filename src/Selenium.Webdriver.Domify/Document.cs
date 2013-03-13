using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public class Document : ISearchContext//: InternetExplorerDriver
    {
        private readonly IWebDriver _driver;

        public Document(IWebDriver driver)
        {
            _driver = driver;
        }

        public Uri Uri
        {
            get
            {
                return new Uri(_driver.Url);
            }
        }

        public IWebElement Body
        {
            get { return _driver.FindElement(By.TagName("Body")); }
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

        public string PageSource
        {
            get { return _driver.PageSource; }

        }

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public void ClearCache()
        {

        }

        public IEnumerable<IWebElement> ElementsWithTag(string tagName)
        {
            return _driver.FindElements(By.TagName(tagName));
        }

        public object Eval(string javascript)
        {
            var js = Driver as IJavaScriptExecutor;
            return js.ExecuteScript(javascript);
        }

        public void GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
           
        }

        private void EnsureAllElementsHaveId()
        {
            string js = "$('*:not([id])').each(function(){ $(this).attr('id', '_id__'+(Math.floor(Math.random()*10000000)+1));  });";
            Eval(js);

        }


        public IWebElement FindElement(By @by)
        {
            return _driver.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _driver.FindElements(@by);
        }
    }
}