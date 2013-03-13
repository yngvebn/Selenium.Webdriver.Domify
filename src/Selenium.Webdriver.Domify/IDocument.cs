using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public interface IDocument : ISearchContext
    {
        Uri Uri { get; }
        IWebElement Body { get; }
        IWebDriver Driver { get; }
        IList<Span> Spans { get; }
        IList<Frame> Frames { get; }
        IList<Div> Divs { get; }
        IList<HyperLink> Links { get; }
        IList<Table> Tables { get; }
        IList<CheckBox> CheckBoxes { get; }
        IEnumerable<IWebElement> ElementsWithTag(string tagName);
        string PageSource { get; }
        INavigationService Navigation { get; }
        void ClearCache();

    }
}