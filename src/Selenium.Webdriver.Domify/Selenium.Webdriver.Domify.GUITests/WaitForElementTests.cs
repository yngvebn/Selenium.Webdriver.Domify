using System;
using NUnit.Framework;

using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
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