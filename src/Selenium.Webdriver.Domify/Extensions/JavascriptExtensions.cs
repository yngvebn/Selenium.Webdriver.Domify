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

        public static void TriggerJavascriptChange(this IWebDriver driver, string elementId)
        {
            driver.ExecuteJavascript("var element = document.getElementById('"+elementId+"'); if ('createEvent' in document) { var evt = document.createEvent('HTMLEvents'); evt.initEvent('change', false, true);element.dispatchEvent(evt);}else element.fireEvent('onchange');");
        }
    }

    
}