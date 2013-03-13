using System;
using System.Text.RegularExpressions;
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


        public static void ExecuteJavascript(this IWebDriver driver, string script)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript(script);
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

        public static T Page<T>(this Document webDriver) where T : Page, new()
        {
            var t = new T {Document = webDriver};
            return t;
        }
        
        public static void WaitUntil<T>(this T element, Predicate<T> predicate) where T : IWebElement
        {
        }
    }
}