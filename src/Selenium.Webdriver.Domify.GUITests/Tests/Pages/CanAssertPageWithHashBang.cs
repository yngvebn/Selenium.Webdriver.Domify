using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Pages
{
    [TestFixture]
    public class CanAssertPageWithHashBang : BrowserScenario
    {
        protected override void Given()
        {

        }

        protected override void When()
        {
            base.Document.Navigation.GoTo("http://localhost:31338/#/12345/yngvebn");
        }

        [Test]
        public void WeShouldBeAtCorrectPage()
        {
            Assert.That(Document.Navigation.IsAtPage<PageWithHashBang>());
        }
    }
}