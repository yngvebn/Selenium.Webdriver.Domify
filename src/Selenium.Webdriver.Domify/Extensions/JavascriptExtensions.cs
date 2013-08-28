using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Webdriver.Domify
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

        public static void TriggerJavascriptEvent(this IWebDriver driver, string elementId, string eventName)
        {
            driver.ExecuteJavascript(string.Format("var element = document.getElementById('{0}');" +
                                                   " if ('createEvent' in document) " +
                                                   "{{ " +
                                                   "var evt = document.createEvent('HTMLEvents'); " +
                                                   "evt.initEvent('{1}', false, true);" +
                                                   "element.dispatchEvent(evt);" +
                                                   "}}" +
                                                   "else element.fireEvent('on{1}');", elementId, eventName));
        }

        public static void TriggerJavascriptChange(this IWebDriver driver, string elementId)
        {
            driver.TriggerJavascriptEvent(elementId, "change");
        }
    }

    
}