using System;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Factories;

namespace Selenium.Webdriver.Domify
{

    public static class Find
    {
        public static By ByClass(string className)
        {
            return OpenQA.Selenium.By.ClassName(className);
        }

        public static By ByClasses(params string[] classNames)
        {
            return OpenQA.Selenium.By.CssSelector(String.Join("", classNames.Select(item => item.Insert(0, "."))));
        }

        public static By ByValue(string value)
        {
            return By("value", value);
        }

        public static By ByValue(Func<string, bool> valueMatcher)
        {
            return new ByValueDelegate(valueMatcher);
        }

        public static By By(string attr, string value, string tagName = "*")
        {
            return OpenQA.Selenium.By.XPath(string.Format(".//{2}[(@{0}='{1}')]", attr, value, tagName));
        }

        public static By ByName(string nameValue)
        {
            return By("name", nameValue);
        }

        public static By ByText(string text)
        {
            return OpenQA.Selenium.By.XPath(string.Format(".//*[text()='{0}']", text));
        }

        public static By ByContainsText(string text)
        {
            return OpenQA.Selenium.By.XPath(string.Format(".//*[text()='(.?+){0}(.?+)']", text));
        }

        public static By ByIndex(int index)
        {
            return OpenQA.Selenium.By.XPath(string.Format("./*[{0}]", index + 1));
        }

        public static By First<T>()
            where T: IWebElement
        {
            string xPath = "";
            foreach(var expr in DOMElementXPathFactory.Get<T>())
            {
                xPath += string.Format(".//{0} | ", expr);
            }
            xPath = "("+xPath.TrimEnd(' ', '|')+")[1]";
            return OpenQA.Selenium.By.XPath(xPath);
        }
    }
}