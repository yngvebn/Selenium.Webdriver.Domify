using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Javascript
{
    public interface IJavascript
    {
        T Execute<T>(IWebElement element);
        T Execute<T>(IWebDriver driver, IWebElement element = null);
    }
}