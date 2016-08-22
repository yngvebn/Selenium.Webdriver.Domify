using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Pages
{
    [TestFixture]
    public class CanAssertPageWithQueryString : BrowserScenario 
    {
        protected override void Given()
        {
         
        }

        protected override void When()
        {
            base.Document.Navigation.GoTo("http://localhost:31338/tests/query?t=12345&u=yngvebn");
        }

        [Test]
        public void WeShouldBeAtCorrectPage()
        {
            Assert.That(Document.Navigation.IsAtPage<PageWithQueryString>());
        }
    }


    [TestFixture]
    public class CanAssertPageWithReplacement : BrowserScenario
    {
        protected override void Given()
        {

        }

        protected override void When()
        {
            base.Document.Navigation.GoTo("http://localhost:31338/tests/query");
        }

        [Test]
        public void WeShouldBeAtCorrectPage()
        {
            Assert.That(Document.Navigation.IsAtPage<PageWithReplacement>());
        }
    }
}