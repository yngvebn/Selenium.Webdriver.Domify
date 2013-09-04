using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.Webdriver.Domify
{
    public static class ByExtensions
    {
        public static ByChained And(this By baseBy, By by)
        {
            return new ByChained(baseBy, by);
        }

        public static ByChained And(this ByChained chain, By by)
        {
            return new ByChained(chain, by);
        }
    }
}