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
        

        [Then]
        public void WeShouldFindFourButtons()
        {
            Assert.That(CurrentPage.Document.Buttons().Count, Is.EqualTo(4));

              
        }

        [Then]
        public void AllButtonsShouldHaveText()
        {
            Assert.That(CurrentPage.Document.Buttons().All(button => !string.IsNullOrEmpty(button.Text)));
        }

        protected override void When()
        {
            
        }
    }
}