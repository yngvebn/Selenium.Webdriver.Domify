using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.Core
{
    public class WebElement : ListWebElements, IWebElement
    {
        private IWebElement _element;

        protected WebElement()
        {
        }

        protected WebElement(IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            _element = element;
        }

        public static T Create<T>(IWebElement element)
            where T : WebElement, new()
        {
            var instance = new T();
            instance.SetWebElement(element);
            instance.Created(element);
            return instance;
        }

        public void Click(bool forceJavascriptClick)
        {
            try
            {
                if (SeleniumElement.Displayed && !forceJavascriptClick)
                {
                    SeleniumElement.Click();
                }
                else
                {
                    this.TriggerJavascriptClick();
                }
            }
            catch (ElementNotVisibleException)
            {
                this.TriggerJavascriptClick();
            }
            catch (InvalidOperationException)
            {
                try
                {
                    this.TriggerJavascriptClick();
                }
                catch
                {
                    TimeSpan timeOut = GlobalConfiguration.Configuration.WaitTimeout;

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

        public void ClickAndWaitForNavigation(TimeSpan timeout = default(TimeSpan))
        {
            string currentUrl = Driver.Url;

            if (timeout == default(TimeSpan))
                timeout = GlobalConfiguration.Configuration.WaitTimeout;

            Click();

            TimeoutManager.Execute(timeout, () =>
                {
                    bool hasNavigatedToAnotherPage = Driver.Url != currentUrl;
                    return hasNavigatedToAnotherPage;
                }, new[] {typeof (StaleElementReferenceException)});
        }

        public void ClickAndWaitForNavigation(Func<bool> navigationHasOccured, TimeSpan timeout = default(TimeSpan))
        {
            if (timeout == default(TimeSpan))
                timeout = GlobalConfiguration.Configuration.WaitTimeout;

            Click();

            TimeoutManager.Execute(timeout, navigationHasOccured, new[] {typeof (StaleElementReferenceException)});
        }

        public T FindNextSibling<T>() where T : WebElement, new()
        {
            IWebElement findElement = Driver.FindElement(By.CssSelector(string.Format("#{0} + {1}", Id, typeof (T).Name)));

            if (findElement == null)
                return null;


            return Create<T>(findElement);
        }

        public string GetAttributeValue(string title)
        {
            return GetAttribute(title);
        }

        public bool HasClass(string className)
        {
            if (className == null)
                throw new ArgumentNullException("className");

            if (ClassName == null)
                return false;

            return ClassName.Split(' ').Any(n => n.Equals(className, StringComparison.CurrentCultureIgnoreCase) || ("." + n).Equals(className, StringComparison.CurrentCultureIgnoreCase));

        }

        public T WaitUntilFound<T>(Func<IWebElement, T> func, TimeSpan timeOut = default(TimeSpan)) where T : WebElement
        {
            if (timeOut == default(TimeSpan))
                timeOut = GlobalConfiguration.Configuration.WaitTimeout;

            var wait = new DefaultWait<IWebElement>(this);
            wait.IgnoreExceptionTypes(typeof (NotFoundException));
            wait.Timeout = timeOut;

            T until = wait.Until(func);

            return until;
        }

        public string ClassName
        {
            get { return SeleniumElement.GetAttribute("class"); }
        }

        public IWebDriver Driver
        {
            get { return ((IWrapsDriver) SeleniumElement).WrappedDriver; }
        }

        public string Id
        {
            get { return GetAttribute("id"); }
            set { this.SetIdForElement(value); }
        }

        private HtmlDocument HtmlDocument
        {
            get
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(Driver.PageSource);
                return doc;
            }
        }
        public string InnerHtml
        {
            get { return HtmlDocument.DocumentNode.SelectSingleNode(this.GetElementXPath()).InnerHtml; }
        }

        public string Name
        {
            get { return GetAttribute("name"); }
        }

        public WebElement Parent
        {
            get
            {
                IWebElement parentElement = FindElement(By.XPath(this.GetElementXPath() + "/.."));
                return Create<HtmlElement>(parentElement);
            }
        }

        public IWebElement SeleniumElement
        {
            get { return _element; }
        }

        public Style Style
        {
            get { return new Style(this); }
        }

        public override IWebElement FindElement(By @by)
        {
            return SeleniumElement.FindElement(@by);
        }

        public override ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return SeleniumElement.FindElements(@by);
        }


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

        public void Click()
        {
            Click(true);
        }

        public string GetAttribute(string attributeName)
        {
            return SeleniumElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return SeleniumElement.GetCssValue(propertyName);
        }

        public string TagName
        {
            get { return SeleniumElement.TagName; }
        }

        public virtual string Text
        {
            get { return SeleniumElement.Text; }
            set
            {
                SeleniumElement.Clear();

                if (!string.IsNullOrEmpty(value))
                    SendKeys(value);
            }
        }

        public bool Enabled
        {
            get { return SeleniumElement.Enabled; }
        }

        public bool Selected
        {
            get { return SeleniumElement.Selected; }
        }

        public Point Location
        {
            get { return SeleniumElement.Location; }
        }

        public Size Size
        {
            get { return SeleniumElement.Size; }
        }

        public bool Displayed
        {
            get { return SeleniumElement.Displayed; }
        }

        protected virtual void Created(IWebElement element)
        {
        }


        protected void SetAttribute(string attributeName, string attributeValue)
        {
            this.SetElementAttribute(attributeName, attributeValue);
        }

        protected void SetText(string value)
        {
            this.SetElementText(value);
        }

        internal void SetWebElement(IWebElement element)
        {
            _element = element;
        }
    }
}