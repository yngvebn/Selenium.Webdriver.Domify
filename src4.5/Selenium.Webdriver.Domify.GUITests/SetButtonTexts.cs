using System;
using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class GetButtonWithSpecialChars : PageScenario<HomeButtons>
    {
        protected override void Given()
        {
            Document.Settings.BaseUri = new Uri("http://localhost:31337");
            base.Given();
        }

        protected override void When()
        {
        }

        [Then]
        public void IShouldFindAButtonWithSpecialCharacters()
        {
            var element = CurrentPage.Document.Find<Button>(Find.ByText("Æøå med mellomrom"));
            Assert.That(element.Any());
        }

        [Then]
        public void IShouldFindAButtonWithNonBreaking()
        {
            var element = CurrentPage.Document.Find<Button>(Find.ByText("Æøå med nonbreaking"));
            Assert.That(element.Any());
        }
    }

    [TestFixture]
    public class SetButtonTexts : PageScenario<HomeButtons>
    {


        protected override void Given()
        {
            Document.Settings.BaseUri = new Uri("http://localhost:31337");
            base.Given();
        }
        
        [Then]
        public void AllButtonsShouldHaveText()
        {
            Assert.That(CurrentPage.Document.Buttons().All(button =>button.Text.Equals("This is my text")));
        }

        protected override void When()
        {
            foreach(var button in CurrentPage.Document.Buttons())
            {
                button.Text = "This is my text";
            }

        }
    }
}