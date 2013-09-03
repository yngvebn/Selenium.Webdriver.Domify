using System;
using System.Globalization;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input")]
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
            Driver.ExecuteJavascript(string.Format("document.getElementById('{0}').value = '{1}'", Id, date.ToString("yyyy-MM-dd")));
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