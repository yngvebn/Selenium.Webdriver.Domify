using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    public class TableTests: PageScenario<HomeSelectLists>
    {
        protected override void When()
        {

        }

        [Then]
        public void TheTableBodyShouldReturnOnlyTwoRows()
        {
            Assert.That(CurrentPage.Table.OwnTableBodies.First().OwnTableRows.Count(), Is.EqualTo(2));
        }
    }
}