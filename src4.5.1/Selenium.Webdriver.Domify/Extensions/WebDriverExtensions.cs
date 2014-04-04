using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.Javascript;

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

        public static IDocument Document(this IWebDriver driver, IDocumentSettings settings = null)
        {
            return new Document(driver, settings);
        }

        public static T WaitUntilFound<T>(this IWebDriver driver, string id, ISearchContext inContext, TimeSpan timeout = default(TimeSpan))
          where T : WebElement, new()
        {
            return driver.WaitUntilFound<T>(By.Id(id), inContext, timeout);
        }


        public static T WaitUntilFound<T>(this IWebDriver driver, By find, ISearchContext inContext, TimeSpan timeout = default(TimeSpan))
            where T : WebElement, new()
        {
            if (timeout == default(TimeSpan))
                timeout = GlobalConfiguration.Configuration.WaitTimeout;

            var wait = new WebDriverWait(driver, timeout);

            IWebElement element = wait.Until(dr => inContext.FindElement(find));

            return element.As<T>();
        }

        public static T WaitUntilFound<T>(this IWebDriver driver, string id, TimeSpan timeout = default(TimeSpan))
            where T : WebElement, new()
        {
            return driver.WaitUntilFound<T>(By.Id(id), timeout);
        }

        public static T WaitUntilFound<T>(this IWebDriver driver, By find, TimeSpan timeout = default(TimeSpan))
            where T: WebElement, new()
        {
            return driver.WaitUntilFound<T>(find, driver, timeout);
        }

        public static void SetWindowSize(this IWebDriver driver, Size size)
        {
            driver.ExecuteJavascript(new SetWindowSize(size));
        }

        public static void SetWindowSize(this IDocument driver, Size size)
        {
            driver.Driver.ExecuteJavascript(new SetWindowSize(size));
        }


        public static void WaitForPageLoaded(this IDocument driver)
        {
            driver.WaitUntil(document => document.IsPageLoaded);
        }
    }
}