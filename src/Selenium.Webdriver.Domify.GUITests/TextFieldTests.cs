using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{

    [TestFixture]
    public class SetIdOnTextBox: BrowserScenario
    {

        
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            Document.Navigation.GetCurrentPage<HomeIndex>().TextBoxWithoutId.Id = "NewId";
        }

        [Then]
        public void TheTextBoxShouldHaveIdSet()
        {
            var textBox = Document.Navigation.GetCurrentPage<HomeIndex>().TextBoxWithoutId;
            
            Assert.That(textBox.Id, Is.EqualTo("NewId"));
        }
    }

    [TestFixture]
    public class OwnListItemsReturnsOnlyImmediateChildren: BrowserScenario
    {

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        private UL list;
        protected override void When()
        {
            list = Document.Navigation.GetCurrentPage<HomeIndex>().NestedList;
        }


        [Then]
        public void TheTextBoxShouldHaveIdSet()
        {
            
            Assert.That(list.OwnListItems.Count, Is.EqualTo(2));
        }
    }
    
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