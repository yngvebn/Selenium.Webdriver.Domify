using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Webdriver.Domify.Extensions
{
    public static class JavascriptExtensions
    {
        public static object ExecuteJavascript(this IWebElement element, string script)
        {
            return ((IWrapsDriver)element).WrappedDriver.ExecuteJavascript(script);
        }

        public static object ExecuteJavascript(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }

    
}