using System;

namespace Selenium.Webdriver.Domify
{
    public interface IDocumentSettings
    {
        /// <summary>
        /// Waiting for an element to exist will time out after this value is reached
        /// </summary>
        TimeSpan WaitTimeout { get; set; }

        /// <summary>
        /// Indicates that we should always wait until the max timeout when looking for an element
        /// </summary>
        bool AlwaysWaitForElement { get; set; }
    }
}