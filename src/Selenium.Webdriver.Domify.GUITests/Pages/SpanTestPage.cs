using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Index", "http://localhost:31338/Home/SpanTest")]
    public class SpanTestPage : Page
    {
        public Div Container
        {
            get { return Document.Div("container"); }
        }
    }
}