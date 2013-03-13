using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Webdriver.Domify.Elements
{

    
        // Summary:
        //     This class helps converting all kinds of html color formats to one uniform
        //     WatiN.Core.HtmlColor object. IE and FireFox return differently formatted
        //     results when retrieving a color, for instance backgroundColor. This class
        //     provides a way to keep your tests browser agnostic when it comes to checking
        //     color values.
        public class HtmlColor
        {
            
            // Summary:
            //     Initializes a new instance of the WatiN.Core.HtmlColor class.
            //
            // Parameters:
            //   value:
            //     The value.
            //
            // Exceptions:
            //   System.FormatException:
            //     Will be thrown if the value can't be converted to a color.
            public HtmlColor(string value)
            {
                OriginalValue = value;
                Color = ColorTranslator.FromHtml(value);
            }

            public static HtmlColor Aqua { get;private set; }
            public static HtmlColor Black { get;private set; }
            public static HtmlColor Blue { get;private set; }
            //
            // Summary:
            //     Returns the System.Drawing.Color wrapped by this class.
            public System.Drawing.Color Color { get; private set; }
            public static HtmlColor Fuchsia { get;private set; }
            public static HtmlColor Gray { get;private set; }
            public static HtmlColor Green { get; private set;}
            public static HtmlColor Lime { get; private set;}
            public static HtmlColor Maroon { get;private set; }
            public static HtmlColor Navy { get; private set;}
            public static HtmlColor Olive { get; private set;}
            public string OriginalValue { get; private set;}
            public static HtmlColor Purple { get; private set;}
            public static HtmlColor Red { get; private set;}
            public static HtmlColor Silver { get; private set;}
            public static HtmlColor Teal { get; private set;}
            //
            // Summary:
            //     Returns the color in a html hex code formatted string
            public string ToHexString { get { return ColorTranslator.ToHtml(Color); } }
            
            public string ToName { get { return Color.Name; }}

            public static HtmlColor White { get; private set; }
            public static HtmlColor Yellow { get; private set; }

            public bool Equals(HtmlColor that)
            {
                return that.Color.Equals(this.Color);
            }
            
            public override bool Equals(object obj)
            {
                return ((HtmlColor) obj).Equals(this);
            }
            public bool Equals(string color)
            {
                return ColorTranslator.FromHtml(color).Equals(Color);
            }
            //
            // Summary:
            //     Serves as a hash function for a particular type.
            //
            // Returns:
            //     A hash code for the current WatiN.Core.HtmlColor.
            public override int GetHashCode()
            {
                return Color.GetHashCode();
            }
            //
            // Summary:
            //     Returns a System.String that represents the current WatiN.Core.HtmlColor.
            //
            // Returns:
            //     A System.String that represents the current WatiN.Core.HtmlColor.
            public override string ToString()
            {
                return ToHexString;
            }
        
    }
    public class Style
    {
        private readonly IWebElement _element;

        public Style(IWebElement element)
        {
            _element = element;
            CssText = _element.GetAttribute("style");
            
        }

        public HtmlColor BackgroundColor { get; private set; }
          public HtmlColor Color { get; private set;}
        //
        // Summary:
        //     Retrieves the CSS text.
        public string CssText { get; private set;}
        //
        // Summary:
        //     Retrieves wheter the object is rendered.
        //
        // Remarks:
        //     For a complete list of the values visit http://msdn.microsoft.com/workshop/author/dhtml/reference/properties/display.asp
        //     .
        public string Display { get; private set;}
        //
        // Summary:
        //     Retrieves the name of the font used for text in the element.
        public string FontFamily { get;private set; }
        //
        // Summary:
        //     Retrieves a value that indicates the font size used for text in the element.
        public string FontSize { get; private set;}
        //
        // Summary:
        //     Retrieves the font style of the element as italic, normal, or oblique.
        public string FontStyle { get; private set;}
        //
        // Summary:
        //     Retrieves the height of the element.
        public string Height { get;private set; }


        public string GetAttributeValue(string attributeName)
        {
            return _element.GetCssValue(attributeName);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

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

       
        public Style Style
        {
            get
            {
                return new Style(this);
            }
        }
    }
}