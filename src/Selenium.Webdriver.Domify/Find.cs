using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    internal class Find
    {
        public static By ByClass(string className)
        {
            return OpenQA.Selenium.By.ClassName(className);
        }

        public static By ByValue(string value)
        {
            return By("value", value);
        }

        public static By By(string attr, string value)
        {
            return OpenQA.Selenium.By.XPath(string.Format(".//*[(@{0}='{1}')]", attr, value));
        }

        public static By ByName(string nameValue)
        {
            return By("name", nameValue);
        }

        public static By ByText(string text)
        {
            return OpenQA.Selenium.By.XPath(string.Format(".//*[text()='{0}']", text));
        }

        public static By ByContainsText(string text)
        {
            return OpenQA.Selenium.By.XPath(string.Format(".//*[text()='(.?+){0}(.?+)']", text));
        }
    }
}