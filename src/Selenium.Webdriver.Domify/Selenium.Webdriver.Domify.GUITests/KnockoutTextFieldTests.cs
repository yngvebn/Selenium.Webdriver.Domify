using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class KnockoutTextFieldTests : BrowserScenario
    {
        private const string TextToTypeIntoTextBox = "Hello world";

        [Test]
        public void CanTypeTextInTextField()
        {
        }

        [SetUp]
        public void SetupBrowser()
        {
        }

        [Then]
        public void TheTextBoxShouldHaveAValue()
        {
            Assert.That(Document.GetCurrentPage<HomeIndex>().KnockoutTextBox.Value, Is.EqualTo(TextToTypeIntoTextBox));
        }

        protected override void Given()
        {
            Document.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            Document.GetCurrentPage<HomeIndex>().KnockoutTextBox.TypeText(TextToTypeIntoTextBox);
        }
    }
}