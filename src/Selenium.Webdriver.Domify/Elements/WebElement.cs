using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Webdriver.Domify.Elements
{
    public abstract class WebElement : IWebElement
    {
        private readonly IWebElement _element;

        public IWebDriver Driver
        {
            get { return ((IWrapsDriver)_element).WrappedDriver; }
        }

        public string Id
        {
            get { return GetAttribute("id"); }
            //set
            //{
            //    var finder = string.Format("document.querySelector('[{0}=\"{1}\"]')", "data-bind", element.GetAttribute("data-bind"));

            //    string setId = "('id', '_id__'+(Math.floor(Math.random()*10000000)+1));";
            //    string js = finder + ".setAttribute" + setId + ";";
            //    Driver.ExecuteJavascript(js);
            //}
        }

        public string Name
        {
            get { return GetAttribute("name"); }
        }

        public T FindNextSibling<T>() where T : WebElement
        {
            IWebElement findElement = Driver.FindElement(By.CssSelector(string.Format("#{0} + {1}", Id, typeof(T).Name)));

            if (findElement == null)
                return null;

            MethodInfo methodInfo = typeof(T).GetMethod("Create");
            return (T)methodInfo.Invoke(null, new object[] { findElement });
        }

        protected WebElement(IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            _element = element;
        }

        public HtmlElement Element(By by)
        {
            var element = FindElement(by);
            return HtmlElement.Create(element);
        }

        public string GetAttributeValue(string title)
        {
            return GetAttribute(title);
        }

        public IWebElement FindElement(By @by)
        {
            return _element.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _element.FindElements(@by);
        }

        public void Clear()
        {
            _element.Clear();
        }

        public void SendKeys(string text)
        {
            _element.SendKeys(text);
        }

        public void Submit()
        {
            _element.Submit();
        }

        public void ClickAndWaitForNavigation(TimeSpan timeout = default(TimeSpan))
        {
            string currentUrl = Driver.Url;

            if (timeout == default(TimeSpan))
                timeout = TimeSpan.FromSeconds(30);

            Click();

            TimeoutManager.Execute(timeout, () =>
                {
                    bool hasNavigatedToAnotherPage = Driver.Url != currentUrl;
                    return hasNavigatedToAnotherPage;
                }, new[] { typeof(StaleElementReferenceException) });
        }

        public void ClickAndWaitForNavigation(Func<bool> navigationHasOccured, TimeSpan timeout = default(TimeSpan))
        {
            if (timeout == default(TimeSpan))
                timeout = TimeSpan.FromSeconds(30);

            Click();

            TimeoutManager.Execute(timeout, navigationHasOccured, new[] { typeof(StaleElementReferenceException) });
        }

        public void Click()
        {
            try
            {
                _element.Click();
            }
            catch (InvalidOperationException)
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    Driver.ExecuteJavascript(string.Format("$('#{0}').click();", Id));
                }
                else
                {
                    var timeOut = TimeSpan.FromSeconds(30);

                    TimeoutManager.Execute(timeOut, item =>
                    {
                        try
                        {
                            item.Click();
                            return true;
                        }
                        catch (InvalidOperationException)
                        {
                            return false;
                        }
                    }, this);
                }
            }
        }

        public bool HasClass(string className)
        {
            if (className == null)
                throw new ArgumentNullException("className");

            if (ClassName == null)
                return false;

            if (ClassName.Length == className.Length)
                return ClassName.Equals(className, StringComparison.InvariantCultureIgnoreCase);

            if (ClassName.IndexOf(className + " ", StringComparison.InvariantCultureIgnoreCase) >= 0)
                return true;

            if (ClassName.IndexOf(" " + className, StringComparison.InvariantCultureIgnoreCase) >= 0)
                return true;

            return false;
        }

        public T WaitUntilFound<T>(Func<IWebElement, T> func, TimeSpan timeOut = default(TimeSpan)) where T : WebElement
        {
            if (timeOut == default(TimeSpan))
                timeOut = TimeSpan.FromSeconds(30);

            var wait = new DefaultWait<IWebElement>(this);
            wait.IgnoreExceptionTypes(typeof(NotFoundException));
            wait.Timeout = timeOut;

            T until = wait.Until(func);

            return until;
        }

        public string InnerHtml
        {
            get { return Text; }
        }

        public string GetAttribute(string attributeName)
        {
            return _element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _element.GetCssValue(propertyName);
        }

        public string ClassName { get { return _element.GetAttribute("class"); } }

        public string TagName { get { return _element.TagName; } }

        public virtual string Text
        {
            get
            {
                return _element.Text;
            }
            set
            {
                _element.Clear();

                if (!string.IsNullOrEmpty(value))
                    SendKeys(value);
            }
        }

        public bool Enabled { get { return _element.Enabled; } }

        public bool Selected { get { return _element.Selected; } }

        public Point Location { get { return _element.Location; } }

        public Size Size { get { return _element.Size; } }

        public bool Displayed { get { return _element.Displayed; } }

        public IList<Span> Spans
        {
            get { return FindElementsByTagName("span").Select(Span.Create).ToList(); }
        }

        public IList<Frame> Frames
        {
            get { return FindElementsByTagName("iframe").Select(Frame.Create).ToList(); }
        }

        public IList<UL> Lists
        {
            get { return FindElementsByTagName("ul").Select(UL.Create).ToList(); }
        }

        public IList<Div> Divs
        {
            get { return FindElementsByTagName("div").Select(Div.Create).ToList(); }
        }

        public IList<HyperLink> Links
        {
            get { return FindElementsByTagName("a").Select(HyperLink.Create).ToList(); }
        }

        public IList<Table> Tables
        {
            get { return FindElementsByTagName("table").Select(Table.Create).ToList(); }
        }

        public IList<TextArea> TextAreas
        {
            get { return FindElementsByTagName("textarea").Select(TextArea.Create).ToList(); }
        }

        public IList<TextField> TextFields
        {
            get { return FindElementsByTagName("input").Where(i => i.GetAttribute("type").Equals("text")).Select(TextField.Create).ToList(); }
        }

        public IList<Button> Buttons
        {
            get
            {
                var buttons = FindElementsByTagName("button").Select(Button.Create).ToList();
                var inputs = FindElementsByTagName("input").Where(c => c.GetAttribute("type").Equals("button")).Select(Button.Create).ToList();
                var allButtons = new List<Button>();
                allButtons.AddRange(buttons);
                allButtons.AddRange(inputs);
                return allButtons;
            }
        }

        public Style Style
        {
            get
            {
                return new Style(this);
            }
        }

        private IEnumerable<IWebElement> FindElementsByTagName(string tagName)
        {
            return FindElements(By.TagName(tagName));
        }
    }
}