using System.Reflection;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class NavigateByPageTitle: BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo(Assembly.GetExecutingAssembly(), "RadioButtons");
        }

        protected override void When()
        {

        }

        [Then]
        public void WeShouldBeAtTheCorrectPage()
        {
            Assert.That(Document.Navigation.IsAtPage<RadioButtonPage>());
        }
    }

    [TestFixture]
    public class IsAtPage : BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<PageWithParametersInUrl>(new {id = 123});
        }

        protected override void When()
        {
            
        }

        [Then]
        public void WeShouldBeOnTheCorrectPage()
        {
            Assert.That(Document.Navigation.IsAtPage<PageWithParametersInUrl>(), Is.True);
        }
    }

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