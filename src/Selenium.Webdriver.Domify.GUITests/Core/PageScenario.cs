namespace Selenium.Webdriver.Domify.GUITests.Core
{
    public abstract class PageScenario<T> : BrowserScenario where T : Page, new()
    {
        protected T CurrentPage { get; private set; }
        protected override void Given()
        {
            CurrentPage = Document.Navigation.GoTo<T>();
        }
    }
}