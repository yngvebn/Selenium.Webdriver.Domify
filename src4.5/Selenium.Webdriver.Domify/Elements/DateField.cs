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
        public void SetDate(DateTime date)
        {
            this.SetAttribute("value", date.ToString(GlobalConfiguration.Configuration.DateFormat));
        }

        public new DateTime Text
        {
            get { return Value; }
            set { Value = value; }
        }

        public DateTime Value
        {
            get { return DateTime.ParseExact(GetAttribute("value"), GlobalConfiguration.Configuration.DateFormat, CultureInfo.InvariantCulture); }
            set
            {
                SetDate(value);
            }
        }
    }
}