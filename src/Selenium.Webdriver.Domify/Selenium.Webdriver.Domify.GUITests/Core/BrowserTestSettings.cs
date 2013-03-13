using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.GUITests.Core
{
    public static class BrowserTestSettings
    {
        public static IDocument Document
        {
            get
            {
                return new Document(Driver);
            }
        }
        public static IWebDriver Driver;

    }
}