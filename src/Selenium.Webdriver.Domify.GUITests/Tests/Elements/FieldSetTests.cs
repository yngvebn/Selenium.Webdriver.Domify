using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class FieldSetTests : BrowserScenario
    {
        private const string elementId = "element";

        protected override void Given()
        {
            Document.Navigation.GoTo<GenericElementPage>(new { id = elementId, tag = "fieldset", type = "", childTags = "legend" });

        }

        private Fieldset element;
        protected override void When()
        {
            element = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.Fieldset(elementId);
        }



        [Then]
        public void CanGetLegendInFieldset()
        {
            Assert.That(element.Legend, Is.Not.Null);
            Assert.That(element.Legend.Text, Is.Not.Empty);
        }

    }
}