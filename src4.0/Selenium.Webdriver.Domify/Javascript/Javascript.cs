using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.Javascript
{
    public abstract class Javascript : IJavascript
    {
        private string Script { get; set; }
        private object[] Arguments { get; set; }

        /// <summary>
        /// Constructs a new executable script
        /// </summary>
        /// <param name="script">The script to be executed</param>
        /// <param name="arguments">Arguments passed here will be available throught a[1] ..  a[n]. The Element is always available as a[0]</param>
        protected Javascript(string script, params object[] arguments)
        {
            Script = script;
            Arguments = arguments;
        }

        /// <summary>
        /// Executes the Javascript always sending the Element as the first arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">This is accessible in the javascript-code as a[0]</param>
        /// <returns></returns>
        public T Execute<T>(IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            return Execute<T>(driver, element);
        }

        public T Execute<T>(IWebDriver driver, IWebElement element = null)
        {
            List<object> obj = new List<object>();
            obj.Add(element);
            obj.AddRange(Arguments);
            var result = (T)
                ((IJavaScriptExecutor)driver).ExecuteScript(WrappedScript, obj.ToArray());
            return result;
        }

        private string WrappedScript
        {
            get
            {
                return string.Format("{0}=function(a) {{ {1} }};return {0}(arguments);", GenerateMethodName(), Script);
            }
        }

        private string GenerateMethodName()
        {
            return string.Format("domify_{0}", GetType().Name);
        }
    }
}