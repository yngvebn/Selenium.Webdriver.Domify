using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.AngularJS
{
    public class CanAssertCorrectTextInDynamicallyCreatedTableCells: PageScenario<AngularPage>
    {
        private Table dynamicTable;

        protected override void When()
        {
            dynamicTable = CurrentPage.AngularTable;
        }

        [Then]
        public void ShouldHaveCorrectTextInAllTableCells()
        {
            for (int i = 1; i < 6; i++)
            {
                Assert.That(dynamicTable.TableRows[0].TableCells[i].Text.Trim(), Is.EqualTo($"Item {i-1}"));
            }
        }

    }
}