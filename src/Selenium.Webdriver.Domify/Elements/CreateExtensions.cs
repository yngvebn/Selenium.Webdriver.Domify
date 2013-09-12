using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public static class CreateExtensions
    {
        public static T As<T>(this IWebElement element)
        {
            return (T)(typeof(T).GetMethod("Create").Invoke(null, new object[] { element }));
        }
    }
}