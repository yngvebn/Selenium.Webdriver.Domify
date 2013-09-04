using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class GetFirstElementTests : PageScenario<HomeButtons>
    {


        [Then]
        public void FindByFirstShouldReturnTheFirstButton()
        {
            Assert.That(CurrentPage.Container.Button(Domify.Find.First<Button>()).Text, Is.EqualTo("Input type button"));
        }

        protected override void When()
        {

        }
    }
}