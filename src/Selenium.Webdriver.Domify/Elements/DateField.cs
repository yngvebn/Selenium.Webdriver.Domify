using System;
using System.Globalization;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type = "date")]
    public class DateField: WebElement
    {
        public static DateField Create(IWebElement element)
        {
            return new DateField(element);
        }

        private DateField(IWebElement element): base(element)
        {
            
        }

        public void SetDate(DateTime date)
        {
            this.SetAttribute("value", date.ToString("yyyy-MM-dd"));
        }

        public new DateTime Text
        {
            get { return Value; }
            set { Value = value; }
        }

        public DateTime Value
        {
            get { return DateTime.ParseExact(GetAttribute("value"), "yyyy-MM-dd", CultureInfo.InvariantCulture); }
            set
            {
                SetDate(value);
            }
        }
    }
}