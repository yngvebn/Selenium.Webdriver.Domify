namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Custom elements", "http://localhost:31338/home/pagewithheadinfo")]
    public class PageWithHeaderInfo : Page
    {
        public string Title
        {
            get { return Document.Header.Title; }
        }

        public string MetaDescription
        {
            get { return Document.Header.Meta["description"].Content; }
        }
    }
}