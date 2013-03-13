using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public interface IDocument : ISearchContext
    {
        /// <summary>
        /// Gets the current URL
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Gets or sets the common settings for the Document
        /// </summary>
        IDocumentSettings Settings { get; }

        /// <summary>
        /// Returns the Body element
        /// </summary>
        IWebElement Body { get; }

        /// <summary>
        /// Returns the WebDriver
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Gets a collection of Spans in the current document
        /// </summary>
        IList<Span> Spans { get; }

        /// <summary>
        /// Gets a collection of IFrames in the current document
        /// </summary>
        IList<Frame> Frames { get; }

        /// <summary>
        /// Gets a collection of Divs in the current document
        /// </summary>
        IList<Div> Divs { get; }

        /// <summary>
        /// Gets a collection of Links in the current document
        /// </summary>
        IList<HyperLink> Links { get; }

        /// <summary>
        /// Gets a collection of Tables in the current document
        /// </summary>
        IList<Table> Tables { get; }

        /// <summary>
        /// Gets a collection of Checkboxes in the current document
        /// </summary>
        IList<CheckBox> CheckBoxes { get; }

        /// <summary>
        /// Gets a collection of elements with the given tag
        /// </summary>
        /// <param name="tagName">The HTML TagName</param>
        /// <returns></returns>
        IEnumerable<IWebElement> ElementsWithTag(string tagName);

        /// <summary>
        /// Returns the entire HTML source for the document
        /// </summary>
        string PageSource { get; }

        /// <summary>
        /// Methods for Navigating the browser
        /// </summary>
        INavigationService Navigation { get; }

    }
}