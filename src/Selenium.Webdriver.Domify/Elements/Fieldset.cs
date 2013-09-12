using System;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
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

        public Legend Legend
        {
            get { return this.Find<Legend>().SingleOrDefault(); }
        }
    }
}