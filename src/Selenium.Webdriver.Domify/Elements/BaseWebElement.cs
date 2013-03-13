using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Webdriver.Domify.Elements
{
    public abstract class WebElement : IWebElement
    {
        private readonly IWebElement _element;
        public IWebDriver Driver
        {
            get { return ((IWrapsDriver) _element).WrappedDriver; }
        }
        public string Id
        {
            get { return GetAttribute("id"); }
            set
            {

            }
        }
        public string Name
        {
            get { return GetAttribute("name"); }
        }

        public T FindNextSibling<T>(By constraint)
        {
            throw new NotImplementedException();
        }

        protected WebElement(IWebElement element)
        {
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
            try
            {
                return _element.FindElement(@by);
            }
            catch
            {
                return null;
            }
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

        public void Click()
        {
            try
            {

                _element.Click();
            }
            catch (InvalidOperationException)
            {
                Driver.ExecuteJavascript(string.Format("$('#{0}').click();", Id));
            }
        }
        public string InnerHtml
        {
            get { return Text; }
        }

        public void WaitUntilExists()
        {

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
        public string Text { get { return _element != null ? _element.Text : null; } }
        public bool Enabled { get { return _element.Enabled; } }
        public bool Selected { get { return _element.Selected; } }
        public Point Location { get { return _element.Location; } }
        public Size Size { get { return _element.Size; } }
        public bool Displayed { get { return _element.Displayed; } }

        public IList<Span> Spans
        {
            get { return FindElementsByTagName("span").Select(Span.Create).ToList(); }
        }

        private IEnumerable<IWebElement> FindElementsByTagName(string tagName)
        {
            return FindElements(By.TagName(tagName));
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
                List<Button> allButtons = new List<Button>();
                allButtons.AddRange(buttons);
                allButtons.AddRange(inputs);
                return allButtons;
            }
        }

        public bool Exists
        {
            get { return _element != null && this.Displayed; }
        }

        public string Style { get { return GetAttribute("style"); } }
    }
}