using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public static class WebDriverExtensions
    {
        public static Uri Uri(this IWebDriver webDriver)
        {
            return new Uri(webDriver.Url);
        }

        public static bool ContainsText(this IDocument driver, string text)
        {
            return driver.PageSource.Replace("&nbsp;", " ").Replace('\u00A0', ' ').Contains(text);
        }

        public static IDocument Document(this IWebDriver driver)
        {
            return new Document(driver);
        }

        public static T WaitUntilFound<T>(this IWebDriver driver, By find, TimeSpan timeout = default(TimeSpan))
            where T: WebElement, new()
        {
            if (timeout == default(TimeSpan))
                timeout = TimeSpan.FromSeconds(30);

            var wait = new WebDriverWait(driver, timeout);

            IWebElement element = wait.Until(dr => dr.FindElement(find));

            return element.As<T>();
        }


        public static void WaitForPageLoaded(this IDocument driver)
        {
            driver.WaitUntil(document => document.IsPageLoaded);
        }
    }
}