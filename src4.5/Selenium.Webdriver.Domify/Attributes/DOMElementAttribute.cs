using System;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DOMElementAttribute : Attribute
    {
        public string Tag { get; set; }
        public string Type { get; set; }

        public string GetXPath()
        {
            return XPath.XPathConstructor.Construct(Tag, string.IsNullOrEmpty(Type) ? "" : "type", Type);
        }

        public DOMElementAttribute(string tag)
        {
            Tag = tag;
        }

        internal bool IsMatch(IWebElement element)
        {
            if ((!string.IsNullOrEmpty(Type) && element.GetAttribute("type") != null) && !element.GetAttribute("type").Equals(Type)) return false;
            return element.TagName.Equals(Tag, StringComparison.InvariantCultureIgnoreCase);
        }

        public string GetCSS()
        {
            if (string.IsNullOrEmpty(Type))
            {
                return Tag;
            }
            else
            {
                return String.Format("{0}[type={1}]", Tag, Type);
            }
        }
    }
}