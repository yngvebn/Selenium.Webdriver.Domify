using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public interface IDocument : ISearchContext, IListWebElements
    {
        /// <summary>
        /// Gets the current URL
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Gets or sets the common settings for the Document
        /// </summary>
        IDocumentSettings Settings { get; }

        IDocumentHeader Header { get; }
        
        IWebDriver Driver { get; }

        /// <summary>
        /// Returns the entire HTML source for the document
        /// </summary>
        string PageSource { get; }

        /// <summary>
        /// Methods for Navigating the browser
        /// </summary>
        INavigationService Navigation { get; }

        bool IsPageLoaded { get; }

        T WaitUntilFound<T>(OpenQA.Selenium.By find, TimeSpan timeout = default(TimeSpan)) where T: WebElement,new() ;
        void Refresh();
    }

    public interface IDocumentHeader
    {
        string Title { get; }
        IDictionary<string, Meta> Meta { get; }
        IList<Style> Styles { get; }
        IList<Link> Links { get; }
        IList<Script> Scripts { get; }
        Base Base { get; }
    }
}