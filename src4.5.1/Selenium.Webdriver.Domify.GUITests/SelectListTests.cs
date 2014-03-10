using System.IO;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class SelectListTests: BrowserScenario
    {
        protected override void Given()
        {
         
            Document.Navigation.GoTo<HomeSelectLists>();
            list = Document.Navigation.GetCurrentPage<HomeSelectLists>().MainList;
        }

        private SelectList list;
        protected override void When()
        {
            list.SelectByText("Option 2");
        }

        [Then]
        public void TheCorretListItemShouldBeSelected()
        {
            Assert.That(list.SelectedOption.Text, Is.EqualTo("Option 2"));
        }
    }
}