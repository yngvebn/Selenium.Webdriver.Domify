using System;
using System.IO;
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

    [TestFixture]
    public class UploadFile: BrowserScenario
    {
        private string file = "";
        protected override void Given()
        {
            var dir = Directory.GetCurrentDirectory();
            file = Path.Combine(dir, "resources\\file.txt");
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            Document.Navigation.GetCurrentPage<HomeIndex>().FileUpload.File = (file);
        }

        [Then]
        public void TheFileShouldBeSetCorrectly()
        {
            Assert.That(Path.GetFileName(Document.Navigation.GetCurrentPage<HomeIndex>().FileUpload.File.ToLower()), Is.EqualTo(Path.GetFileName(file.ToLower())));
        }
    }

    [TestFixture]
    public class WaitForElementValueTests : BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            Document.Navigation.GetCurrentPage<HomeIndex>().DelayedTextBox.WaitUntil(c => !string.IsNullOrEmpty(c.Value));
        }

        [Then]
        public void TheTextShouldBeDisplayed()
        {
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().DelayedTextBox.Value, Is.EqualTo("5 seconds elapsed"));
        }

    }
    [TestFixture]
    public class WaitForElementTests : BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
        }

        [Then]
        public void TheTextShouldBeDisplayed()
        {
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().DelayedLink.Text, Is.EqualTo("Link"));
        }

    }
}