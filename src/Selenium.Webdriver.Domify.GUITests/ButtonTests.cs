using System;
using System.Drawing;
using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class ButtonTests : PageScenario<HomeButtons>
    {
        protected override void Given()
        {
            Document.Settings.BaseUri = new Uri("http://localhost:31337");
            base.Given();
        }
        

        [Then]
        public void WeShouldFindSixButtons()
        {
            Assert.That(CurrentPage.Document.Buttons().Count, Is.EqualTo(6));

              
        }

        [Then]
        public void AllButtonsShouldHaveText()
        {
            Assert.That(CurrentPage.Document.Buttons().All(button => !string.IsNullOrEmpty(button.Text)));
        }

        protected override void When()
        {
            Document.SetWindowSize(new Size(768,1024));
        }
    }
}