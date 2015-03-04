using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Buttons", "/Home/Buttons")]
    public class HomeButtons : Page
    {

        public Div Container
        {
            get { return Document.Div("container"); }
        }
    }
}