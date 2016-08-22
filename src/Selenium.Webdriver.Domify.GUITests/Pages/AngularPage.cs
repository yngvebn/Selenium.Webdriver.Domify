using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("AngularPage", "http://localhost:31338/Home/Angular")]
    public class AngularPage : Page
    {
        public Table AngularTable => Document.Table("angular-table");
    }
}