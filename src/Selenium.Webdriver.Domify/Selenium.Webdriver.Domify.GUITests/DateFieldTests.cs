using System;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class DateFieldTests : BrowserScenario
    {
        private readonly DateTime _textToTypeIntoTextBox = new DateTime(2013,03,18);

        [SetUp]
        public void SetupBrowser()
        {

        }

        [Then]
        public void TheTextBoxShouldHaveAValue()
        {
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().DateBox.Value, Is.EqualTo(_textToTypeIntoTextBox));
        }

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {

            Document.Navigation.GetCurrentPage<HomeIndex>().DateBox.SetDate(_textToTypeIntoTextBox);
        }
    }

    [TestFixture]
    public class NavigationTests : BrowserScenario
    {

        [SetUp]
        public void SetupBrowser()
        {

        }

        [Then]
        public void WeShouldBeAtHomePage()
        {
            Assert.That(Document.Navigation.IsAtPage<HomeIndex>());
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>(), Is.Not.Null);
        }

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {

        }
    }
}