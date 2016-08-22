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
}