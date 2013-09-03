using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Webdriver.Domify.Elements
{
    public abstract class WebElement : IWebElement
    {
        private readonly IWebElement _element;

        public IWebDriver Driver
        {
            get { return ((IWrapsDriver)SeleniumElement).WrappedDriver; }
        }

        public string Id
        {
            get { return GetAttribute("id"); }
            set { this.SetIdForElement(value); }
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
            return SeleniumElement.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return SeleniumElement.FindElements(@by);
        }


        public WebElement Parent { get { return HtmlElement.Create(FindElement(By.XPath(Driver.GetElementXPath(this)+"/.."))); } }

        public void Clear()
        {
            SeleniumElement.Clear();
        }

        public void SendKeys(string text)
        {
            SeleniumElement.SendKeys(text);
        }

        public void Submit()
        {
            SeleniumElement.Submit();
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
                SeleniumElement.Click();
            }
            catch (ElementNotVisibleException)
            {
                this.TriggerJavascriptClick();
            }
            catch (InvalidOperationException)
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    Driver.TriggerJavascriptEvent(Id, "click");
                }
                else if (string.IsNullOrEmpty(Id))
                {
                    this.TriggerJavascriptClick();
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
            return SeleniumElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return SeleniumElement.GetCssValue(propertyName);
        }

        public string ClassName { get { return SeleniumElement.GetAttribute("class"); } }

        public string TagName { get { return SeleniumElement.TagName; } }

        public virtual string Text
        {
            get
            {
                return SeleniumElement.Text;
            }
            set
            {
                SeleniumElement.Clear();

                if (!string.IsNullOrEmpty(value))
                    SendKeys(value);
            }
        }

        public bool Enabled { get { return SeleniumElement.Enabled; } }

        public bool Selected { get { return SeleniumElement.Selected; } }

        public Point Location { get { return SeleniumElement.Location; } }

        public Size Size { get { return SeleniumElement.Size; } }

        public bool Displayed { get { return SeleniumElement.Displayed; } }

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

        public IWebElement SeleniumElement
        {
            get { return _element; }
        }

        private IEnumerable<IWebElement> FindElementsByTagName(string tagName)
        {
            return FindElements(By.TagName(tagName));
        }
    }
}