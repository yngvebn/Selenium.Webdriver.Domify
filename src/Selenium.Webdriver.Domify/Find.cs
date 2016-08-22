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
        private readonly bool _partial;

        public ByTextFinder(string text, bool partial)
        {
            _text = CleanSpace(text);
            _xpathFormat = partial ? ".//*[text()[contains(., '{0}')]]" : ".//*[text()['{0}']]";
            _partial = partial;
        }

        private string CleanSpace(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, @"[\s|\u00A0]", " ").Replace(" ", " ").Trim();
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
            doc.LoadHtml(html.Replace("\r\n", ""));
            var root = doc.DocumentNode;
            if (context is IWebElement)
            {
                root = doc.DocumentNode.SelectSingleNode((WebElement.Create<HtmlElement>((IWebElement) context)).GetElementXPath());
                // This operation could potentially generate a new Id for the element. Reload the HTML
                doc.LoadHtml(((OpenQA.Selenium.Remote.RemoteWebElement)context).WrappedDriver.PageSource);
                root = doc.DocumentNode.SelectSingleNode((WebElement.Create<HtmlElement>((IWebElement)context)).GetElementXPath());
            }
            var htmlNodeCollection = root.SelectNodes(string.Format(_xpathFormat, _text));

            if(htmlNodeCollection == null) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            var foundNodes = htmlNodeCollection.Where(n => n.ChildNodes.Any(c => c.NodeType == HtmlNodeType.Text)).Where(c => IsMatch(c.ChildNodes, _text, _partial));
            

            //var foundNodes = _partial ? nodes.Where(n => CleanSpace(n.InnerText).Contains(_text)) : nodes.Where(n => CleanSpace(n.InnerText.Replace(Environment.NewLine, "")).Equals(_text));


            List<IWebElement> returnList = new List<IWebElement>();

            List<string> xpaths = new List<string>();
            foreach (var node in foundNodes.Reverse())
            {
                if(xpaths.All(n => n.IndexOf(node.XPath, System.StringComparison.Ordinal) != 0))
                    xpaths.Add(node.XPath);
            }

            foreach (var xpath in xpaths)
            {
                IWebElement thisNode = context.FindElement(By.XPath(xpath));
                    returnList.Add(thisNode);
            }

            return new ReadOnlyCollection<IWebElement>(returnList);

        }

        private bool IsMatch(HtmlNodeCollection childNodes, string textToFind, bool partial)
        {
            if (partial)
            {
                return childNodes.Any(n => CleanSpace(n.InnerText.Replace(Environment.NewLine, "")).Contains(textToFind));
            }
            else
            {
                return childNodes.Any(n => CleanSpace(n.InnerText.Replace(Environment.NewLine, "")).Equals(textToFind));
            }

        }
    }
}