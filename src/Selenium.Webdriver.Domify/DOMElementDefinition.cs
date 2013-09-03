using System;

namespace Selenium.Webdriver.Domify
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DOMElementAttribute: Attribute
    {
        public string Tag { get; set; }

        public DOMElementAttribute(string tag)
        {
            Tag = tag;
        }
    }
}