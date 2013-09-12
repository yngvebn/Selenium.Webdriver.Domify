using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class TextAreaTests : BrowserScenario
    {
        private const string ListId = "textbox1";

        private string text = "textarea text";
        protected override void Given()
        {
            Document.Navigation.GoTo<GenericElementPage>(new { id = ListId, tag = "textarea", text="Text that should be replaced", type = ""});

        }

        private TextArea element;
        protected override void When()
        {
            element = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.TextArea(ListId);
            element.Text = text;
        }



        [Then]
        public void CanGetListItemAtSpecificIndex()
        {
            Assert.That(element.Text, Is.EqualTo(text));
        }

    }
}