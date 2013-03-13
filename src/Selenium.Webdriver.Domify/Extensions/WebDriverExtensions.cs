using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Extensions
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

        public static void WaitUntil<T>(this T element, Predicate<T> predicate, int timeOut = 30) where T : IWebElement
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while(true)
            {
                try
                {
                    if (predicate(element))
                        break;
                }
                catch
                {
                    
                }
                if (stopwatch.Elapsed.TotalSeconds > timeOut)
                    throw new TimeoutException(string.Format("Timed out after {0} seconds while waiting", stopwatch.Elapsed.TotalSeconds));
            }
        }
    }
}