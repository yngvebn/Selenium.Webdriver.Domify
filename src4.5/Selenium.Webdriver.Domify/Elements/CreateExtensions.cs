using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    public static class CreateExtensions
    {
        public static T As<T>(this IWebElement element) where T: WebElement, new()
        {
            return WebElement.Create<T>(element);
        }
    }
}