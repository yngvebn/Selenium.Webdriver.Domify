using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class CanGetParentObject: BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            
        }

        [Then]
        public void TextBoxShouldDisplayText()
        {
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().KnockoutTextBox.Parent.Id, Is.EqualTo("parentContainer"));
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().TextBoxWithoutId.Parent.Id, Is.EqualTo("parentContainer2"));
        }
    }
}