using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    public class DOMElementCssFactory
    {
        public static string[] Get<T>()
            where T : IWebElement
        {
            IEnumerable<DOMElementAttribute> attributes = GetDomElementAttributes<T>();
            return attributes.Select(att => att.GetCSS()).ToArray();
        }

        private static IEnumerable<DOMElementAttribute> GetDomElementAttributes<T>()
        {
            var attribute = typeof(T).GetCustomAttributes(typeof(DOMElementAttribute), false).Cast<DOMElementAttribute>();
            return attribute.ToList();

        }
    }
}