using System;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("*")]
    [Obsolete("Will be removed in v2.0")]
    public class Element : WebElement
    {
        public static Element Create(IWebElement element)
        {
            return new Element(element);
        }

        private Element(IWebElement element) :
            base(element)
        {

        }
    }

    [DOMElement("fieldset")]
    public class Fieldset : WebElement
    {
        public static Fieldset Create(IWebElement element)
        {
            return new Fieldset(element);
        }

        private Fieldset(IWebElement element) :
            base(element)
        {

        }
    }
}