using System;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input")]
    [Obsolete("Will be removed in v2.0. Use more specific selectors like Button, TextField etc.")]
    public class Input : WebElement
    {
        public static Input Create(IWebElement element)
        {
            return new Input(element);
        }

        private Input(IWebElement element) :
            base(element)
        {

        }
    }
}