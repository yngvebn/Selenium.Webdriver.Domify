using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class NavigationTests : BrowserScenario
    {

        [SetUp]
        public void SetupBrowser()
        {

        }

        [Then]
        public void WeShouldBeAtHomePage()
        {
            Assert.That(Document.Navigation.IsAtPage<HomeIndex>());
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>(), Is.Not.Null);
        }

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {

        }
    }
}