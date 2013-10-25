using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;
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

        public static By ByText(string text, bool partial = false)
        {
            return new ByTextFinder(text, partial);
        }

        public static By ByContainsText(string text)
        {
            return ByText(text, true);
        }

        public static By ByIndex(int index)
        {
            return OpenQA.Selenium.By.XPath(string.Format("./*[{0}]", index + 1));
        }

        public static By First<T>()
            where T : IWebElement
        {
            string xPath = "";
            foreach (var expr in DOMElementXPathFactory.Get<T>())
            {
                xPath += string.Format(".//{0} | ", expr);
            }
            xPath = "(" + xPath.TrimEnd(' ', '|') + ")[1]";
            return OpenQA.Selenium.By.XPath(xPath);
        }
    }

    public class ByTextFinder : By
    {
        private readonly string _text;
        private readonly string _xpathFormat;

        public ByTextFinder(string text, bool partial)
        {
            _text = text;
            _xpathFormat = partial ? ".//*[contains(., '{0}')]" : ".//*[text()[normalize-space()='{0}']]";
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return FindElements(context).SingleOrDefault();
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            var html = context is IWebElement ? ((OpenQA.Selenium.Remote.RemoteWebElement)context).WrappedDriver.PageSource : ((OpenQA.Selenium.Remote.RemoteWebDriver)(context)).PageSource;
            var doc = new HtmlDocument();
            HtmlNode.ElementsFlags.Remove("form");
            doc.LoadHtml(html);
            var root = doc.DocumentNode;
            if (context is IWebElement)
            {
                root = doc.DocumentNode.SelectSingleNode((WebElement.Create<HtmlElement>((IWebElement) context)).GetElementXPath());
            }
            var nodes = root.SelectNodes(string.Format(_xpathFormat, _text));
            
            if (nodes == null) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            
            var node = nodes.LastOrDefault();
            var xpath = node.XPath;


            return context.FindElements(By.XPath(xpath));
        }
    }
}