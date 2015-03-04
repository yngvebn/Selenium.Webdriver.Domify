using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class NavigationWithQuerystring: BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>(new {queryValue = "abc"});
        }

        protected override void When()
        {

        }

        [Then]
        public void WeShouldHaveAUrlWithQueryString()
        {
            Assert.That(Document.Uri.Query, Is.EqualTo("?queryValue=abc"));    
        }
    }
}