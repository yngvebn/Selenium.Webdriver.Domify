using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;

namespace Selenium.Webdriver.Domify.Factories
{
    
    public class DOMElementFilterFactory
    {
        public static Func<IWebElement, bool> Get<T>()
            where T: IWebElement
        {
            IEnumerable<DOMElementAttribute> attributes = GetDomElementAttributes<T>();
            return element => attributes.Any(attribute => attribute.IsMatch(element));
        }

        private static IEnumerable<DOMElementAttribute> GetDomElementAttributes<T>()
        {
            var attribute = typeof(T).GetCustomAttributes(typeof(DOMElementAttribute), false).Cast<DOMElementAttribute>();
            return attribute.ToList();
        }
    }
}