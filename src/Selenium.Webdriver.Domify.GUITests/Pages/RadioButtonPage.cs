using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("RadioButtons", "http://localhost:31338/Home/RadioButtons")]
    public class RadioButtonPage: Page
    {
        public RadioButton Radio1 { get { return Document.RadioButton("radio1"); } }
        public RadioButton Radio2 { get { return Document.RadioButton("radio2"); } }
    }
}