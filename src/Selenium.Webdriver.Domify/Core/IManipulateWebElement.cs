namespace Selenium.Webdriver.Domify.Core
{
    public interface IManipulateWebElement<in TWebElement>
        where TWebElement : BaseWebElement
    {
        void Set(TWebElement element, object value);
        object Get(TWebElement element);
    }
}