using System;
using System.Threading;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    public class PageDescriptionAttribute : Attribute
    {
        public PageDescriptionAttribute(string title, string url)
        {
            Url = new Uri(url);
            Title = title;
        }
        public Uri Url { get; set; }

        public string Title { get; set; }
    }
}