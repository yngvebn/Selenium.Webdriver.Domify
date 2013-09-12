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
            Assert.That(Document.Navigation.GetCurrentPage<HomeIndex>().DateBox.Text, Is.EqualTo(_textToTypeIntoTextBox));
        }

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {

            Document.Navigation.GetCurrentPage<HomeIndex>().DateBox.Text = _textToTypeIntoTextBox;

        }
    }
}