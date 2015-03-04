using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class SetTextToHiddenTextBox: BrowserScenario
    {
        private const string TextBoxId = "textbox1";

        protected override void Given()
        {
            Document.Navigation.GoTo<GenericElementPage>(new {tag = "input", type = "text", id = TextBoxId});
        }

        protected override void When()
        {
            Document.TextField(TextBoxId).Text = "I am visible!";
            Assert.That(Document.TextField(TextBoxId).Value, Is.EqualTo("I am visible!"));
            TextBoxIsHidden();
        }

        private void TextBoxIsHidden()
        {
            Document.TextField(TextBoxId).Style.Display = "none";
        }

        [Then]
        public void TheTextBoxShouldNotBeDisplayed()
        {
            Assert.That(Document.TextField(TextBoxId).IsVisible(), Is.False);
        }

        [Then]
        public void WeCanStillSetTheTextInTheTextBox()
        {
            Document.TextField(TextBoxId).Value = "I am hidden!";
            Assert.That(Document.TextField(TextBoxId).Value, Is.EqualTo("I am hidden!"));
        }
    }
}