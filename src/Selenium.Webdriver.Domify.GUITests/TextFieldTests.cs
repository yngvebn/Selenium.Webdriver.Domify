using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    
    [TestFixture]
    public class TextFieldTests : BrowserScenario
    {
        private const string TextToTypeIntoTextBox = "Hello world";

        [SetUp]
        public void SetupBrowser()
        {
        }

        [Then]
        public void TheTextBoxShouldHaveAValue()
        {
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().TextBox.Value, Is.EqualTo(TextToTypeIntoTextBox));
        }

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            
            Document.Navigation.GetCurrentPage<HomeIndex>().TextBox.Value = (TextToTypeIntoTextBox);
        }
    }
}