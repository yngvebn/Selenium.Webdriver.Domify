using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class OwnListItemsReturnsOnlyImmediateChildren: BrowserScenario
    {

        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }

        private UL list;
        protected override void When()
        {
            list = Document.Navigation.GetCurrentPage<HomeIndex>().NestedList;
        }


        [Then]
        public void TheTextBoxShouldHaveIdSet()
        {
            
            Assert.That(list.OwnListItems.Count, Is.EqualTo(2));
        }
    }

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
        public void TheTextBoxShouldHaveIdSet()
        {

            Assert.That(list.OwnListItems.Count, Is.EqualTo(2));
        }
    }
}