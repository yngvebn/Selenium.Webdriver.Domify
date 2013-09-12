using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;

namespace Selenium.Webdriver.Domify.Factories
{
    public class DOMElementXPathFactory
    {
        public static string[] Get<T>()
            where T : IWebElement
        {
            IEnumerable<DOMElementAttribute> attributes = GetDomElementAttributes<T>();
            return attributes.Select(att => att.GetXPath()).ToArray();
        }

        private static IEnumerable<DOMElementAttribute> GetDomElementAttributes<T>()
        {
            var attribute = typeof(T).GetCustomAttributes(typeof(DOMElementAttribute), false).Cast<DOMElementAttribute>();
            return attribute.ToList();

        }
    }
}