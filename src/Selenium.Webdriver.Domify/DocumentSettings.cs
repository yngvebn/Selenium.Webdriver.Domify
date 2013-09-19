using System;

namespace Selenium.Webdriver.Domify
{
    public class DocumentSettings : IDocumentSettings
    {
        public TimeSpan WaitTimeout { get; set; }
        public bool AlwaysWaitForElement { get; set; }
    }
}