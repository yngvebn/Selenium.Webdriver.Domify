using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Custom elements", "http://localhost:31338/home/customelements")]
    public class CustomElementsPage: Page
    {
        public MyElement MyCustomElement
        {
            get { return Document.Find<MyElement>("myElement"); }
        }
    }

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