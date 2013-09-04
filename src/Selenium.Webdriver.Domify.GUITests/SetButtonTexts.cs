using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class SetButtonTexts : PageScenario<HomeButtons>
    {



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