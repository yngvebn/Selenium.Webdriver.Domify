using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class UncheckCheckBoxTests : BrowserScenario
    {
        private const string ListId = "textbox1";

        protected override void Given()
        {
            Document.Navigation.GoTo<GenericElementPage>(new { id = ListId, tag = "input", text = "Text that should be replaced", type = "checkbox" });

        }

        private CheckBox element;
        protected override void When()
        {
            element = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.CheckBox(ListId);
            element.Checked = true;
            element.Checked = false;
        }



        [Then]
        public void CanGetListItemAtSpecificIndex()
        {
            Assert.That(element.Checked, Is.EqualTo(false));
        }

    }
}