using System;

namespace Selenium.Webdriver.Domify
{
    public class DocumentSettings : IDocumentSettings
    {
        public bool EnsureAllElementsHaveId { get; set; }
        public TimeSpan WaitTimeout { get; set; }
        public bool AlwaysWaitForElement { get; set; }
    }
}