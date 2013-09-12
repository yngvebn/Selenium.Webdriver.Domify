using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.Javascript;

namespace Selenium.Webdriver.Domify
{
    public static class JavascriptExtensions
    {

        public static object ExecuteJavascript(this IWebDriver driver, string script, IWebElement element = null)
        {
            return new GenericJavascript(script).Execute<object>(driver, element);
        }


        public static T ExecuteJavascript<T>(this IWebDriver driver, IJavascript javascript, params object[] arguments)
        {
            return javascript.Execute<T>(driver);
        }

        public static T ExecuteJavascript<T>(this IWebElement element, IJavascript javascript, params object[] arguments)
        {
            return javascript.Execute<T>(((WebElement)element).SeleniumElement);
        }

        public static void ExecuteJavascript(this IWebElement element, IJavascript javascript, params object[] arguments)
        {
            element.ExecuteJavascript<object>(javascript, arguments);
            
        }


        public static string GetElementXPath(this IWebElement element)
        {
            if (string.IsNullOrEmpty(element.GetAttribute("id")))
            {
                SetIdForElement(element, GenerateRandomId());
            }
            return element.ExecuteJavascript<string>(new GetElementXPath());
            
        }

        public static void SetElementText(this IWebElement element, string text)
        {
            element.ExecuteJavascript(new SetElementText(text));
        }

        public static void SetElementAttribute(this IWebElement element, string attributeName, object attributeValue)
        {
            element.ExecuteJavascript(new SetElementAttribute( attributeName, attributeValue));
        }

        private static string GenerateRandomId()
        {
            Random random = new Random();
            var idNumber = random.Next(1000000);
            string id = string.Format("___s_w_d_{0}", idNumber);
            return id;
        }

        public static string GenerateIdForElement(this IWebElement element)
        {
            string id = GenerateRandomId();
            element.SetIdForElement(id);
            return id;
        }

        public static void SetIdForElement(this IWebElement element, string id)
        {
            element.SetElementAttribute("id", id);
        }

        public static void TriggerJavascriptClick(this IWebElement element)
        {
            element.ExecuteJavascript(new TriggerJavascriptClick());
        }

        public static void SetElementValue(this IWebElement element, string value)
        {
            element.ExecuteJavascript(new SetElementValue(value));
        }

        public static void TriggerJavascriptEvent(this IWebElement element, params object[] eventName)
        {
            element.ExecuteJavascript(new TriggerJavascriptEvents(eventName));
        }

        public static void ClearTextField(this IWebElement element)
        {
            element.ExecuteJavascript(new SetElementValue(""));
        }

        public static void TriggerJavascriptChange(this IWebElement element)
        {
            element.TriggerJavascriptEvent("keydown", "keyup", "keypress", "change", "blur");
        }
    }
}


