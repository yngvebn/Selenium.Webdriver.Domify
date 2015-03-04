using System;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
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