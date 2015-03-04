using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class OwnListItemsWithoutIDReturnsOnlyImmediateChildren : BrowserScenario
    {

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        private UL list;
        protected override void When()
        {
            list = Document.Navigation.GetCurrentPage<HomeIndex>().NestedKnockoutList;
        }


        [Then]
        public void WeShouldOnlyGetTwoImmediateChildren()
        {

            Assert.That(list.OwnListItems.Count, Is.EqualTo(2));
        }
    }
}