using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    public static class WebDriverExtensions
    {
     
        public static Uri Uri(this IWebDriver webDriver)
        {
            return new Uri(webDriver.Url);
        }

        public static bool ContainsText(this Document driver, string text)
        {
            return driver.PageSource.Contains(text);
        }

        public static IDocument Document(this IWebDriver driver)
        {
            return new Document(driver);
        }
        public static bool Exists(this IWebElement element)
        {
            return element.IsVisible();
        }

        public static string InnerHtml(this IWebElement element)
        {
            return element.Text;
        }

        public static bool IsVisible(this IWebElement element)
        {
            if (!element.Displayed)
                return false;

            return element.GetCssValue("display") != "none";
        }

        public static void WaitUntil<T>(this T element, Predicate<T> predicate, TimeSpan timeOut = default(TimeSpan)) where T : IWebElement
        {
            

            if (timeOut == default(TimeSpan)) timeOut = TimeSpan.FromSeconds(30);
            TimeoutManager.Execute(timeOut, predicate, element);

        }
    }
}