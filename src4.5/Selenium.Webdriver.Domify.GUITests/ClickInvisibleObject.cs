using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class ClickInvisibleObject: BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            Document.Navigation.GetCurrentPage<HomeIndex>().InvisibleButton.Click();
        }

        [Then]
        public void TextBoxShouldDisplayText()
        {
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().KnockoutTextBox.Text, Is.EqualTo("invisible clicked"));
        }
    }
}