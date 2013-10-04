using System;

namespace Selenium.Webdriver.Domify
{
    public class DocumentSettings : IDocumentSettings
    {
        public TimeSpan WaitTimeout { get; set; }
        public bool AlwaysWaitForElement { get; set; }

        public string DateFormat { get; set; }

        public DocumentSettings()
        {
            WaitTimeout = TimeSpan.FromSeconds(34);
            AlwaysWaitForElement = false;
            DateFormat = "yyyy-MM-dd";
        }
    }
}