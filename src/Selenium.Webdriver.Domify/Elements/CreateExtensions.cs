using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public static class CreateExtensions
    {
         public static Div AsDiv(this IWebElement element)
         {
             return Div.Create(element);
         }

        public static T As<T>(this IWebElement element)
        {
            return (T)(typeof(T).GetMethod("Create").Invoke(null, new object[] { element }));
        }
    }
}