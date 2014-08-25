using System;
using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.ElementStyles
{
    public class VisibilityTests: PageScenario<VisibilityPage>
    {
        protected override void Given()
        {
            Document.Settings.BaseUri = new Uri("http://localhost:31338");
            base.Given();
        }

        protected override void When()
        {
        }

        [Then]
        public void WeShouldFindOneVisibleButton()
        {
            var buttons = CurrentPage.Document.Find<Button>(Find.ByText("Button")).Where(d => d.IsVisible());
            Assert.That(buttons.Count(), Is.EqualTo(1));
        }

        [Then]
        public void WeShouldFindTwoButtonsTotal()
        {
            var buttons = CurrentPage.Document.Find<Button>(Find.ByText("Button"));
            Assert.That(buttons.Count(), Is.EqualTo(2));
        }
    }
}