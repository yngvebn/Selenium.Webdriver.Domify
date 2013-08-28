using System;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [Ignore("Will only work for HTML5-enabled browsers")]
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
}