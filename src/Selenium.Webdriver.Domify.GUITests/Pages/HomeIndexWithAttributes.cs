using OpenQA.Selenium.Support.PageObjects;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Index", "http://localhost:31337/Home/Index")]
    public class HomeIndexWithAttributes : Page
    {
        [FindsBy(How = How.Id, Using = "textbox")]
        public virtual TextField TextBox { get; set; }
    }
}